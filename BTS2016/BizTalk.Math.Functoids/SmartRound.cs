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
            this.SetupResourceAssembly("BizTalk.Logical.Functoids.LogicalResources", Assembly.GetExecutingAssembly());
            base.HasSideEffects = false;

            //Setup the Name, ToolTip, Help Description, and the Bitmap for this functoid
            SetName("IDS_SMARTROUND_NAME");
            SetTooltip("IDS_SMARTROUND_TOOLTIP");
            SetDescription("IDS_SMARTROUND_DESCRIPTION");
            SetBitmap("IDB_SMARTROUND_BITMAP");

            //Set the function name that is to be called when invoking this functoid.
            // To test the map in Visual Studio, this functoid does not need to be in the GAC.
            // If using this functoid in a deployed BizTalk app. then it must be in the GAC
            AddScriptTypeSupport(ScriptType.CSharp);

            base.Category = FunctoidCategory.Math;
            base.SetMinParams(2);
            base.SetMaxParams(2);

            base.AddInputConnectionType(ConnectionType.AllExceptRecord); //first parameter
            base.AddInputConnectionType(ConnectionType.AllExceptRecord); //second parameter

            base.OutputConnectionType = ConnectionType.AllExceptRecord;
            base.RequiredGlobalHelperFunctions = InlineGlobalHelperFunction.IsNumeric;

            base.SetScriptBuffer(ScriptType.CSharp, GetCSharpBuffer());
        }

        private string GetCSharpBuffer()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("private string SmartRound(double inputNumber, int roundNumber)\n");
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
