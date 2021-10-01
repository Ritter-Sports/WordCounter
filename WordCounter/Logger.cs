using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter;

public class Logger
{
    private readonly ILogger _logger;

    public Logger(ILogger<Logger> logger)
    {
        _logger = logger;
    }

    public void PrintInfo(string text)
    {
        _logger.LogInformation(DateTime.UtcNow+" "+text);
    }
    public void PrintWarning(string text)
    {
        _logger.LogWarning(DateTime.UtcNow + " " + text);
    }
    public void PrintError(string text)
    {
        _logger.LogError(DateTime.UtcNow + " " + text);
    }
}

