using Microsoft.BizTalk.BaseFunctoids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BizTalk.Math.Functoids
{
    [Serializable]
    public class SmartRound : BaseFunctoid
    {
        public SmartRound() :
            base()
        {
            //ID for this functoid
            this.ID = 11302;

            // resource assembly must be ProjectName.ResourceName if building with VS.Net
            SetupResourceAssembly("BizTalk.Math.Functoids.Properties.Resources", Assembly.GetExecutingAssembly());

            //Setup the Name, ToolTip, Help Description, and the Bitmap for this functoid
            SetName("IDS_SMARTROUND_NAME");
            SetTooltip("IDS_SMARTROUND_TOOLTIP");
            SetDescription("IDS_SMARTROUND_DESCRIPTION");
            SetBitmap("IDS_SMARTROUND_BITMAP");

            //category for this functoid. This functoid goes under the String Functoid Tab in the
            base.Category = FunctoidCategory.Math;

            // Set the limits for the number of input parameters.
            base.SetMinParams(2);
            base.SetMaxParams(2);

            // Add one line of code as set out below for each input param. For multiple input params, each line would be identical.
            base.AddInputConnectionType(ConnectionType.AllExceptRecord); //first parameter
            base.AddInputConnectionType(ConnectionType.AllExceptRecord); //second parameter

            // The functoid output can go to any node type.
            base.OutputConnectionType = ConnectionType.AllExceptRecord;

            base.RequiredGlobalHelperFunctions = InlineGlobalHelperFunction.IsNumeric;

            base.SetScriptBuffer(ScriptType.CSharp, GetCSharpBuffer());
        }

        private string GetCSharpBuffer()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("public string SmartRound(double inputNumber, int roundNumber)\n");
            builder.Append("{\n");
            builder.Append("\t\treturn (System.Math.Round(inputNumber, roundNumber)).ToString(\"F\"+ roundNumber);\n");
            builder.Append("}\n");
            return builder.ToString();
        }

        //private double SmartRound(double inputNumber, int roundNumber)
        //{
        //    return System.Math.Round(inputNumber, roundNumber);
        //}
    }
}
