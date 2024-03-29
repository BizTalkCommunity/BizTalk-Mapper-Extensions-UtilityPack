using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.BizTalk.BaseFunctoids;
using System.Reflection;
using Microsoft.XLANGs.Core;
using System.ComponentModel;
using System.Collections;
using Microsoft.XLANGs.BaseTypes;

namespace BizTalk.ResourceContext.Functoids
{
    [Serializable]
    public class OrchVarRetriever : BaseFunctoid
	{
		public OrchVarRetriever():base()
		{
            //ID for this functoid
            this.ID = 11100;

            // resource assembly must be ProjectName.ResourceName if building with VS.Net
            SetupResourceAssembly("BizTalk.ResourceContext.Functoids.ContextResources", Assembly.GetExecutingAssembly());

            //Setup the Name, ToolTip, Help Description, and the Bitmap for this functoid
            SetName("IDS_ORCVARFUNCTOID_NAME");
            SetTooltip("IDS_ORCVARFUNCTOID_TOOLTIP");
            SetDescription("IDS_ORCVARFUNCTOID_DESCRIPTION");
            SetBitmap("IDS_ADVCOMPAREFUNCTOID_BITMAP");

            // Set the limits for the number of input parameters.
            // Minimum and maximum parameters that the functoid accepts 
            this.SetMinParams(1);
			this.SetMaxParams(1);

            //category for this functoid. This functoid goes under the String Functoid Tab in the
            //VS.Net toolbox for functoids.
            this.Category = FunctoidCategory.String;

            // Set the limits for the number of input parameters.
            this.SetMinParams(1);
            this.SetMaxParams(1);

            // Add one line of code as set out below for each input param. For multiple input params, each line would be identical.
            AddInputConnectionType(ConnectionType.AllExceptRecord); //first input

            // The functoid output can go to any node type.
            this.OutputConnectionType = ConnectionType.AllExceptRecord;

            // Set the function name that is to be called when invoking this functoid.
            // To test the map in Visual Studio, this functoid does not need to be in the GAC.
            // If using this functoid in a deployed BizTalk app. then it must be in the GAC
            SetExternalFunctionName(GetType().Assembly.FullName, GetType().FullName, "RetrieveVariable");
        }

        /// <summary>
        /// Function to retrieve variable value from running orchestration using reflection. Null is returned if the
        /// variable value cannot be fetched for whatever reason.
        /// </summary>
        /// <param name="variableName">Name of the variable to fetch the value for. Case sensitive.</param>
        /// <returns>The value of the variable as string. All values are converted to string. If the 
        /// value cannot be fetched null is returned.</returns>
        public string RetrieveVariable(string variableName)
        {
            try
            {
                // Check root service. This will be null if the map is not executed from an orchestration but just in a port.
                if (Service.RootService != null)
                {
                    // Loop through all state managers in reverse order. Variables are defined on multiple levels when scopes are
                    // used. The reverse order loop makes sure we find the inner (scope) variable first. This is the version that contains 
                    // the value.
                    for (int stateMgrIndex = Service.RootService._stateMgrs.Length - 1; stateMgrIndex >= 0; stateMgrIndex--)
                    {
                        // Cast the state manager as context.
                        Context xLangContext = Service.RootService._stateMgrs[stateMgrIndex] as Context;
                        if (xLangContext != null)
                        {
                            string retVal = RetrieveVariableFromXLangContext(xLangContext, variableName);

                            if (retVal != null)
                            {
                                return retVal;
                            }
                        }
                    }
                }

                return null;
            }
            catch(Exception ex)
            {
                // if an exception occurs just return null. Probably better to raise an exception if the value
                // could not be retrieved.
                return "";
            }
        }

        /// <summary>
        /// Loop through all the fields in a Xlang context instance using reflection. Return the value if the variable
        /// with name 'variableName' is found.
        /// </summary>
        /// <param name="xLangContext">XlangContext to enumerate fields.</param>
        /// <param name="variableName">Name of the variable to retrieve.</param>
        /// <returns>The value of the variable as string or null if the variable is not found.</returns>
        private string RetrieveVariableFromXLangContext(Context xLangContext, string variableName)
        {
            
            foreach (FieldInfo fieldInfo in xLangContext.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                string retVal = RetrieveVariableFromField(fieldInfo, xLangContext, variableName);

                if (retVal != null)
                {
                    return retVal;
                }
            }

            return null;
        }

        /// <summary>
        /// Check the UserVariableAttribute of the field to see if it matches the name of variable in 'variableName'.
        /// The actual name if the variable is different from what we see in the VS UI. Most of the times two underscores
        /// are added to the variable.
        /// </summary>
        /// <param name="fieldInfo">FieldInfo object to inspect.</param>
        /// <param name="xLangContext">XlangContext that hosts the field.</param>
        /// <param name="variableName">Name of the variable to retrieve.</param>
        /// <returns>The value of the variable as string or null if the variable is not found.</returns>
        private string RetrieveVariableFromField(FieldInfo fieldInfo, Context xLangContext, string variableName)
        {
            // Get the user variable attributes of the field
            object[] attributeObjects = fieldInfo.GetCustomAttributes(typeof(Microsoft.XLANGs.Core.UserVariableAttribute), false);

            if (attributeObjects != null)
            {
                // Loop through attributes. Will probably always just contain one attribute. Use for each
                // to play on the save side.
                foreach (object attributeObject in attributeObjects)
                {
                    if (attributeObject.GetType() == typeof(Microsoft.XLANGs.Core.UserVariableAttribute))
                    {
                        // if the name of the variable matches variable name attribute return the value.
                        UserVariableAttribute userVariableAttribute = attributeObject as UserVariableAttribute;
                        if (userVariableAttribute.Name.Equals(variableName))
                        {
                            return fieldInfo.GetValue(xLangContext).ToString();
                        }
                    }
                }
            }

            return null;
        }
    }
}