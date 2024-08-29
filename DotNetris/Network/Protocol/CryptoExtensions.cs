using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetris.Network.Server.Database.Models;
using Google.Protobuf;

namespace DotNetris.Network.Protocol
{
    public partial class SignedGameSettings
    {
        public static SignedGameSettings Sign(GameSettings settings, User user)
        {
            user.GameToken ??= new byte[64];
            // generate the game token
            Geralt.SecureRandom.Fill(user.GameToken);

            // serialize the settings
            byte[] serializedSettings = settings.ToByteArray();

            // generate what we need to sign
            Span<byte> signingMaterial = stackalloc byte[user.GameToken.Length + serializedSettings.Length];
            Geralt.Spans.Concat(signingMaterial, serializedSettings, user.GameToken);

            // sign the material with the user's key
            byte[] signature = new byte[Geralt.BLAKE2b.MaxTagSize];
            Geralt.BLAKE2b.ComputeTag(signature, signingMaterial, user.UserKey);

            return new SignedGameSettings()
            {
                Settings = settings,
                UserTag = ByteString.CopyFrom(user.GameToken),
                Signature = ByteString.CopyFrom(signature)
            };
        }

        public bool Verify(User user)
        {
            if (user.GameToken == null)
            {

                // user is not current in game
                return false;
            }
            // check the tag matches first
            if (!Geralt.ConstantTime.Equals(
                    UserTag.Span,
                    user.GameToken
                ))
            {
                return false;
            }
            // check the signature matches


            // generate the signing material
            byte[] serializedSettings = Settings.ToByteArray();
            Span<byte> signingMaterial = stackalloc byte[user.GameToken.Length + serializedSettings.Length];
            Geralt.Spans.Concat(signingMaterial, serializedSettings, user.GameToken);

            // verify the signature
            if (Geralt.BLAKE2b.VerifyTag(Signature.Span, signingMaterial, user.UserKey))
            {
                Array.Clear(user.GameToken);
                return true;
            }
            return false;
        }
    }
}
