using Microsoft.BizTalk.BaseFunctoids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BizTalk.Logical.Functoids
{
    [Serializable]
    public class Negate : BaseFunctoid
    {
        public Negate()
            : base()
        {
            //ID for this functoid
            this.ID = 10910;

            // resource assembly must be ProjectName.ResourceName if building with VS.Net
            this.SetupResourceAssembly("BizTalk.Logical.Functoids.LogicalResources", Assembly.GetExecutingAssembly());
            base.HasSideEffects = false;

            //Setup the Name, ToolTip, Help Description, and the Bitmap for this functoid
            SetName("IDS_NEGATE_NAME");
            SetTooltip("IDS_NEGATE_TOOLTIP");
            SetDescription("IDS_NEGATE_DESCRIPTION");
            SetBitmap("IDB_NEGATE");

            //Set the function name that is to be called when invoking this functoid.
            // To test the map in Visual Studio, this functoid does not need to be in the GAC.
            // If using this functoid in a deployed BizTalk app. then it must be in the GAC
            AddScriptTypeSupport(ScriptType.CSharp);

            base.Category = FunctoidCategory.Logical;
            base.SetMinParams(1);
            base.SetMaxParams(1);

            base.AddInputConnectionType(ConnectionType.AllExceptRecord); //first parameter

            base.OutputConnectionType = ConnectionType.AllExceptRecord;
            base.RequiredGlobalHelperFunctions = InlineGlobalHelperFunction.IsNumeric;

            base.SetScriptBuffer(ScriptType.CSharp, GetCSharpBuffer());
        }

        private string GetCSharpBuffer()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("private double NegateNumber(double inputNumber)\n");
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
