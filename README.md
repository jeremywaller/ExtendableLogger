# ExtendableLogger
An easily extendable logging solution for any C# application.


To set up log4net logging:  
1. Create a web.config or app.config  
2. Copy the xml text below into that file. If you have an existing web or app config file, add the following config sections where they belong within your existing file.   
3. Update the appSettings keys for your application.  
4. Update the RollingFileAppender's file value to point to your log file path. Log4net config examples: https://logging.apache.org/log4net/release/config-examples.html  


Example usage:
```c#
//NOTE!! This example shows how to enable log4net as a logger for DEBUG, ERROR, and INFO levels.  
//The contrived "External" logger is used for DEBUG and INFO levels.

//Based on this example, calling logManager.Debug or logManager.Info will log to both External and Log4Net, 
//while calling logManager.Error will only log to Log4Net.

LogManager logManager = new LogManager();

logManager.AddLogger(LoggerType.External, LogLevel.Debug | LogLevel.Info);
logManager.AddLogger(LoggerType.Log4Net, LogLevel.Debug | LogLevel.Error | LogLevel.Info, "myServiceName log");

logManager.Error("Error message.");
logManager.Debug("Debug message", ExceptionObject);
logManager.Info(new Exception("Info message."));
```


```xml

<configuration>
  <configSections>
		<section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
  </configSections>
  
	<log4net>
		<appender name="ConsoleAppender" type="log4net.Appender.ConsoleAppender">
			<layout type="log4net.Layout.PatternLayout">
			<conversionPattern value="%date [%thread] %-5level %logger [%ndc] - %message%newline" />
			</layout>
		</appender>
		<appender name="RollingFile" type="log4net.Appender.RollingFileAppender">
			<file value="c:\logs\Logging.log" />
			<appendToFile value="true" />
			<maximumFileSize value="100KB" />
			<maxSizeRollBackups value="2" />
			<layout type="log4net.Layout.PatternLayout">
				<conversionPattern value="%level %thread %logger - %message%newline" />
			</layout>
		</appender>
		<root>
			<level value="ALL" />
			<appender-ref ref="ConsoleAppender" />
			<appender-ref ref="RollingFile" />
		</root>
	</log4net>
</configuration>
```
