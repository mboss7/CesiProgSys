using System;

namespace CesiprogSys.LOG

interface ILogs : LogsManager
{
    void startThread();
    void startLog();
    void logInfo();
    void logError();
}