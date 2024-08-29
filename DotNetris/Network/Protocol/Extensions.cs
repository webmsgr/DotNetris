using Google.Protobuf;

namespace DotNetris.Network.Protocol;

partial class GeneralResult
{
    public static GeneralResult Failure(string message)
    {
        return new GeneralResult()
        {
            Fail = new Failure()
            {
                Message = message
            }
        };
    }
    public static GeneralResult Success(string message)
    {
        return new GeneralResult()
        {
            Ok = new Ok()
            {
                Message = message
            }
        };
    }
    /// <summary>
    /// Unwraps a GeneralResult, either throwing or returning the OK message
    /// </summary>
    /// <returns>The ok message</returns>
    /// <exception cref="Exception">When the contained result is an error</exception>

    public string Unwrap()
    {
        switch (ResultCase)
        {
            case ResultOneofCase.Ok:
                return Ok.Message;
            case ResultOneofCase.Fail:
                throw new Exception(Fail.Message);
            default:
                throw new NotImplementedException("invalid type for unwrap");
        }
    }
}

partial class LeaderboardResponse
{
    public static LeaderboardResponse Fail(string message)
    {
        return new LeaderboardResponse()
        {
            Failure = new Failure()
            {
                Message = message
            }
        };
    }
    public static LeaderboardResponse Success(IEnumerable<ReplayEntry> entries)
    {
        return new LeaderboardResponse()
        {
            Ok = new Leaderboard()
            {
                Entries = { entries }
            }
        };
    }
    /// <summary>
    /// Unwraps a Leaderboard response, either throwing or returning the entries
    /// </summary>
    /// <returns>Leaderboard entries sorted by score</returns>
    /// <exception cref="Exception">When the contained result is an error</exception>

    public ReplayEntry[] Unwrap()
    {
        switch (ResultCase)
        {
            case ResultOneofCase.Ok:
                return Ok.Entries.ToArray();
            case ResultOneofCase.Failure:
                throw new Exception(Failure.Message);
            default:
                throw new NotImplementedException("invalid type for unwrap");
        }
    }
}

partial class RequestGameResponse
{
    public static RequestGameResponse Fail(string message)
    {
        return new RequestGameResponse()
        {
            Failure = new Failure()
            {
                Message = message
            }
        };
    }

    public static RequestGameResponse Success(SignedGameSettings settings)
    {
        return new RequestGameResponse()
        {
            Ok = settings
        };
    }

    /// <summary>
    /// Unwraps a RequestGameResponse, either throwing or returning the signed game settings
    /// </summary>
    /// <returns>The signed game settings</returns>
    /// <exception cref="Exception">When the contained result is an error</exception>

    public SignedGameSettings Unwrap()
    {
        switch (ResultCase)
        {
            case ResultOneofCase.Ok:
                return Ok;
            case ResultOneofCase.Failure:
                throw new Exception(Failure.Message);
            default:
                throw new NotImplementedException("invalid type for unwrap");
        }
    }
}

partial class ReplayListResponse
{
    public static ReplayListResponse Failure(string message)
    {
        return new ReplayListResponse()
        {
            Fail = new Failure()
            {
                Message = message
            }
        };
    }

    public static ReplayListResponse Success(ReplayEntry[] replays)
    {
        return new ReplayListResponse()
        {
            Ok = new ReplayList()
            {
                Entries = { replays }
            }
        };
    }

    /// <summary>
    /// Unwraps a ReplayListResponse, either throwing or returning the replay list
    /// </summary>
    /// <returns>The array of replays</returns>
    /// <exception cref="Exception">When the contained result is an error</exception>

    public ReplayEntry[] Unwrap()
    {
        switch (ResultCase)
        {
            case ResultOneofCase.Ok:
                return Ok.Entries.ToArray();
            case ResultOneofCase.Fail:
                throw new Exception(Fail.Message);
            default:
                throw new NotImplementedException("invalid type for unwrap");
        }
    }
}

partial class DownloadReplayResponse
{
    public static DownloadReplayResponse Failure(string message)
    {
        return new DownloadReplayResponse()
        {
            Fail = new Failure()
            {
                Message = message
            }
        };
    }

    public static DownloadReplayResponse Success(SerializedReplay replay)
    {
        return new DownloadReplayResponse()
        {
            Ok = replay
        };
    }

    /// <summary>
    /// Unwraps a DownloadReplayResponse, either throwing or returning the replay list
    /// </summary>
    /// <returns>The replay</returns>
    /// <exception cref="Exception">When the contained result is an error</exception>

    public SerializedReplay Unwrap()
    {
        switch (ResultCase)
        {
            case ResultOneofCase.Ok:
                return Ok;
            case ResultOneofCase.Fail:
                throw new Exception(Fail.Message);
            default:
                throw new NotImplementedException("invalid type for unwrap");
        }
    }
}


partial class Replay
{
    public Replay(SignedGameSettings settings, Inputs[] inputs)
    {
        Tag = settings;
        Replay_ = ByteString.CopyFrom(
                inputs.Select(i => (byte)i)
                .ToArray()
            );
    }

    public IEnumerable<Inputs> GetInputs()
    {
        return Replay_
            .Select(i => (Inputs)i);
    }
}

partial class SerializedReplay
{
    public SerializedReplay(Replay replay)
    {
        Settings = replay.Tag.Settings;
        this.replay_ = replay.Replay_;
    }
}