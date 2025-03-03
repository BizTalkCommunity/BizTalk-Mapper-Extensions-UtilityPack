using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.BizTalk.BaseFunctoids;
using System.Text.RegularExpressions;

namespace BizTalk.String.Functoids
{
    [Serializable]
    public class ReplaceMultipleSpaces : BaseFunctoid
    {
        public ReplaceMultipleSpaces()
            : base()
        {
            //ID for this functoid
            this.ID = 10011;

            // resource assembly must be ProjectName.ResourceName if building with VS.Net
            SetupResourceAssembly("BizTalk.String.Functoids.StringResources", Assembly.GetExecutingAssembly());

            //Setup the Name, ToolTip, Help Description, and the Bitmap for this functoid
            SetName("IDS_REMOVEMULTIPLESPACESFUNCTOID_NAME");
            SetTooltip("IDS_REMOVEMULTIPLESPACESFUNCTOID_TOOLTIP");
            SetDescription("IDS_REMOVEMULTIPLESPACESFUNCTOID_DESCRIPTION");
            SetBitmap("IDS_REMOVEMULTIPLESPACESFUNCTOID_BITMAP");

            //category for this functoid. This functoid goes under the String Functoid Tab in the
            this.Category = FunctoidCategory.String;

            // Set the limits for the number of input parameters. This example: 1 parameter
            this.SetMinParams(1);
            this.SetMaxParams(1);

            // Add one line of code as set out below for each input param. For multiple input params, each line would be identical.
            AddInputConnectionType(ConnectionType.AllExceptRecord); //first input

            // The functoid output can go to any node type.
            this.OutputConnectionType = ConnectionType.AllExceptRecord;

            // Set the function name that is to be called when invoking this functoid.
            // To test the map in Visual Studio, this functoid does not need to be in the GAC.
            // If using this functoid in a deployed BizTalk app. then it must be in the GAC
            //SetExternalFunctionName(GetType().Assembly.FullName, GetType().FullName, "RemoveZeros");

            SetScriptBuffer(ScriptType.CSharp, this.GetCSharpBuffer());
            HasSideEffects = false;

        }

        private string GetCSharpBuffer()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("public static string ReplaceMultipleSpacesBySingleSpace(string text)\n");
            builder.Append("{\n");
            builder.Append("\t\tstring result = Regex.Replace(text, @\"\\s + \", \" \");\n");
            builder.Append("\t\treturn result;\n");
            builder.Append("}\n");
            return builder.ToString();
        }

        /// <summary>
        /// Function that Replace Multiple Spaces with a Single Space
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ReplaceMultipleSpacesBySingleSpace(string text)
        {
            string result = Regex.Replace(text, @"\s+", " ");  
            return result;
        }

    }
}

