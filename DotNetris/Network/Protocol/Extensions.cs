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