﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System.IO;

namespace Microsoft.PowerPlatform.Administration.Helpers
{
    public class Logger
    {
        private string _logLocation;
        private string _genericLog;
        private string _errorLog;
        private string _roleAssignmentsReportsDir;
        private string _roleRemovalLogsDir;
        private string _AddRoleLogsDir;

        public string GenericLog
        {
            get
            {
                return _genericLog;
            }
        }

        public string UnProcessedEnvironmetsWithExceptionsLog
        {
            get
            {
                return _errorLog;
            }
        }

        public string RoleAssignmentsReportsDir
        {
            get
            {
                return _roleAssignmentsReportsDir;
            }

        }

        public string AddRoleLogsDir
        {
            get
            {
                return _AddRoleLogsDir;
            }

        }

        public string RoleRemovalLogsDir
        {
            get
            {
                return _roleRemovalLogsDir;
            }
        }

        public string LogLocation
        {
            get
            {
                return _logLocation;
            }
        }

        public Logger(string logLocation)
        {
            _logLocation = logLocation;
            _genericLog = Path.Combine(logLocation, "GenericLog.txt");
            _errorLog = Path.Combine(logLocation, "ErrorLog.txt");
        }

        public void CreateRoleAssignmentReportsDirectory()
        {
            _roleAssignmentsReportsDir = Path.Combine(_logLocation, "RoleAssignmentReports");

            Directory.CreateDirectory(_roleAssignmentsReportsDir);
        }

        public void CreateRoleRemovalLogsDirectory()
        {
            _roleRemovalLogsDir = Path.Combine(_logLocation, "RoleRemovalLogs");
            Directory.CreateDirectory(_roleRemovalLogsDir);
        }

        public void CreateAddRoleLogsDirectory()
        {
            _AddRoleLogsDir = Path.Combine(_logLocation, "AddRoleToUserLogs");
            Directory.CreateDirectory(_AddRoleLogsDir);
        }

        public void LogGeneric(string log)
        {
            File.AppendAllLines(_genericLog, new string[] { log });
        }

        public void LogException(string log)
        {
            File.AppendAllLines(_errorLog, new string[] { log });
        }

        public string GetUsersWithRoleAssignmentsReportPath(string logLocation, string orgName, string roleName)
        {
            return Path.Combine(logLocation, $"{orgName}_{roleName}_Users.csv");
        }

        public string GetRoleRemovalLogPath(string logLocation, string orgName, string roleName)
        {
            return Path.Combine(logLocation, $"{orgName}_{roleName}_RemovalLog.txt");
        }

        public void InitializeRoleAssignmentReport(string logFile)
        {
            File.WriteAllLines(logFile, new string[] { $"SystemUserId, UserPrincipalName, AccessMode, IsDisabled, IsLicensed" });
        }

        public void LogToFile(string filePath, string log)
        {
            File.AppendAllLines(filePath, new string[] { log });
        }

        public void LogToFile(string filePath, string[] logs)
        {
            File.AppendAllLines(filePath, logs);
        }
    }
}
