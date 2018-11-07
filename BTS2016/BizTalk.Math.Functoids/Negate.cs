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
    public class Negate : BaseFunctoid
    {
        public Negate()
            : base()
        {
            //ID for this functoid
            this.ID = 11301;

            // resource assembly must be ProjectName.ResourceName if building with VS.Net
            SetupResourceAssembly("BizTalk.Math.Functoids.Properties.Resources", Assembly.GetExecutingAssembly());

            //Setup the Name, ToolTip, Help Description, and the Bitmap for this functoid

            SetName("IDS_NEGATE_NAME");
            SetTooltip("IDS_NEGATE_TOOLTIP");
            SetDescription("IDS_NEGATE_DESCRIPTION");
            SetBitmap("IDS_NEGATE_BITMAP");

            //category for this functoid. This functoid goes under the String Functoid Tab in the
            this.Category = FunctoidCategory.Math;

            // Set the limits for the number of input parameters. This example: 1 parameter
            this.SetMinParams(1);
            this.SetMaxParams(1);

            // Add one line of code as set out below for each input param. For multiple input params, each line would be identical.
            base.AddInputConnectionType(ConnectionType.AllExceptRecord); //first parameter
            // The functoid output can go to any node type.
            base.OutputConnectionType = ConnectionType.AllExceptRecord;

            base.RequiredGlobalHelperFunctions = InlineGlobalHelperFunction.IsNumeric;

            base.SetScriptBuffer(ScriptType.CSharp, GetCSharpBuffer());
            HasSideEffects = false;
        }

        private string GetCSharpBuffer()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("public double NegateNumber(double inputNumber)\n");
            builder.Append("{\n");
            builder.Append("\t\treturn inputNumber * (-1);\n");
            builder.Append("\t}\n");
            return builder.ToString();
        }

        private double NegateNumber(double inputNumber)
        {
            return inputNumber * (-1);
        }

    }
}
