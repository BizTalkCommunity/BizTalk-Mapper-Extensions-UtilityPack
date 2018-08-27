using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.BizTalk.BaseFunctoids;
using System.Reflection;

namespace BizTalk.Conversion.Functoids
{
    [Serializable]
    public class ToIntConversion : BaseFunctoid
    {
        public ToIntConversion()
            : base()
        {
            //ID for this functoid
            this.ID = 10303;

            // resource assembly must be ProjectName.ResourceName if building with VS.Net
            SetupResourceAssembly("BizTalk.Conversion.Functoids.ConversionResource", Assembly.GetExecutingAssembly());

            //Setup the Name, ToolTip, Help Description, and the Bitmap for this functoid
            SetName("IDS_TOINTFUNCTOID_NAME");
            SetTooltip("IDS_TOINTFUNCTOID_TOOLTIP");
            SetDescription("IDS_TOINTFUNCTOID_DESCRIPTION");
            SetBitmap("IDS_TOINTFUNCTOID_BITMAP");

            //category for this functoid. This functoid goes under the String Functoid Tab in the
            this.Category = FunctoidCategory.Conversion;

            // Set the limits for the number of input parameters. This example: 1 parameter
            this.SetMinParams(3);
            this.SetMaxParams(3);

            // Add one line of code as set out below for each input param. For multiple input params, each line would be identical.
            AddInputConnectionType(ConnectionType.All); //first input

            // The functoid output can go to any node type.
            this.OutputConnectionType = ConnectionType.All;

            // Set the function name that is to be called when invoking this functoid.
            // To test the map in Visual Studio, this functoid does not need to be in the GAC.
            // If using this functoid in a deployed BizTalk app. then it must be in the GAC
            SetExternalFunctionName(GetType().Assembly.FullName, GetType().FullName, "ParseToNumber");

            //If you use SetScriptBuffer you don't need to use SetExternalFunctionName and the
            //functoid don't need to be added to GAC
            //SetScriptBuffer(ScriptType.CSharp, this.GetCSharpBuffer());
            //HasSideEffects = false;
        }

        /// <summary>
        /// The real operation to be executed by the functoid
        /// You need change this code and add your logic here
        /// </summary>
        public string ParseToNumber(string value, string decimalSeparator, string groupSeparator)
        {
            if (string.IsNullOrEmpty(value))
                return "0";

            System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();


            if (string.IsNullOrEmpty(decimalSeparator))
            {
                provider.NumberDecimalSeparator = ".";
            }
            else
            {
                provider.NumberDecimalSeparator = decimalSeparator;
                provider.NumberGroupSeparator = groupSeparator;
            }

            string number = string.Empty;

            number = Convert.ToInt64(Convert.ToDecimal(value, provider)).ToString();
            return number;
        }

        /// <summary>
        /// You need change this code and add your logic here
        /// Don't change the name of the function, only the content
        /// </summary>
        private string GetCSharpBuffer()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("public string ParseToNumber(string value, string decimalSeparator, string groupSeparator)\n");
            builder.Append("{\n");
            builder.Append("\tif (string.IsNullOrEmpty(value))\n");
            builder.Append("\tif (string.IsNullOrEmpty(value))\n");
            builder.Append(@"\t\treturn ""0"";\n");
            builder.Append("\tSystem.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();\n");
            builder.Append("\tif (string.IsNullOrEmpty(decimalSeparator))\n");
            builder.Append("\t{\n");
            builder.Append(@"\t\tprovider.NumberDecimalSeparator = ""."";\n");
            builder.Append("\t}\n");
            builder.Append("\telse\n");
            builder.Append("\t{\n");
            builder.Append("\t\tprovider.NumberDecimalSeparator = decimalSeparator;\n");
            builder.Append("\t\tprovider.NumberGroupSeparator = groupSeparator;\n");
            builder.Append("\t}\n");
            builder.Append("\tstring number = string.Empty;\n");
            builder.Append("\tnumber = Convert.ToInt64(Convert.ToDecimal(value, provider)).ToString();\n");
            builder.Append("\treturn number;\n");
            builder.Append("}\n");
            return builder.ToString();
        }
    }
}
