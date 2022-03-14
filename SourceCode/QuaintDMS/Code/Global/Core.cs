using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace QuaintDMS.Code.Global
{
    // Application alert type for alert box
    public enum AlertType
    {
        Success,
        Error,
        Warning,
        Information,
        Question,
        Other
    }

    public class Core
    {
        // Application copyright
        public static string Copyright(bool longText = false)
        {
            try
            {
                //string text = "<strong>&copy; 2018 <a href='http://quaintpark.com' target='_blank' class='text-quaintpark'>Quaint Park</a></strong>.";
                string text = "<strong>&copy; 2018 Q Care</strong>.";

                if (longText)
                    text += " All rights reserved.";

                return text;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Application version
        public static string Version()
        {
            try
            {
                string text = "Version 1.0";
                return text;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Application alert box
        public static int AlertBoxInternal = 10000;

        public static void AlertBox(System.Web.UI.Page page, Type type, AlertType alertType, string message)
        {
            string key = string.Empty;
            string script = string.Empty;
            string title = string.Empty;
            string modalType = string.Empty;

            if (alertType == AlertType.Success)
            {
                title = "Success";
                modalType = "green";
            }
            else if (alertType == AlertType.Error)
            {
                title = "Error";
                modalType = "red";
            }
            else if (alertType == AlertType.Warning)
            {
                title = "Warning";
                modalType = "orange";
            }
            else if (alertType == AlertType.Information)
            {
                title = "Information";
                modalType = "blue";
            }
            else if (alertType == AlertType.Question)
            {
                title = "Question";
                modalType = "dark";
            }
            else if (alertType == AlertType.Other)
            {
                modalType = "purple";
            }

            script = "$.alert({ title:'" + title + "', content:'" + message + "', type:'" + modalType + "', animation: 'scale', closeAnimation: 'scale'});";
            ScriptManager.RegisterStartupScript(page, type, key, script, true);
        }

        public static string AlertBox(AlertType alertType, string message)
        {
            string alertMessage = string.Empty;
            string title = string.Empty;
            string alertTypeClass = string.Empty;

            if (alertType == AlertType.Success)
            {
                title = "<h4><i class='fa fa-check-circle'></i> Success</h4>";
                alertTypeClass = "alert-success";
            }
            else if (alertType == AlertType.Error)
            {
                title = "<h4><i class='fa fa-times-circle'></i> Error</h4>";
                alertTypeClass = "alert-danger";
            }
            else if (alertType == AlertType.Warning)
            {
                title = "<h4><i class='fa fa-exclamation-circle'></i> Warning</h4>";
                alertTypeClass = "alert-warning";
            }
            else if (alertType == AlertType.Information)
            {
                title = "<h4><i class='fa fa-info-circle'></i> Information</h4>";
                alertTypeClass = "alert-info";
            }
            else if (alertType == AlertType.Question)
            {
                title = "<h4><i class='fa fa-question-circle'></i> Question</h4>";
                alertTypeClass = "alert-info";
            }
            else if (alertType == AlertType.Other)
            {
                title = "";
                alertTypeClass = "";
            }

            message = "<p>" + message + "</p>";
            alertMessage = "<div class='alert " + alertTypeClass + " alert-dismissible auto-close' role='alert'><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>" + title + message + "</div>";
            return alertMessage;
        }
    }
}