using Microsoft.BizTalk.BaseFunctoids;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace BizTalk.String.Functoids
{
    public class RegexFunctoid : BaseFunctoid
    {
        public RegexFunctoid()
            : base()
        {
            //ID for this functoid
            this.ID = 10009;

            // resource assembly must be ProjectName.ResourceName if building with VS.Net
            SetupResourceAssembly("BizTalk.String.Functoids.StringResources", Assembly.GetExecutingAssembly());

            //Setup the Name, ToolTip, Help Description, and the Bitmap for this functoid
            SetName("IDS_REGEXFUNCTOID_NAME");
            SetTooltip("IDS_REGEXFUNCTOID_TOOLTIP");
            SetDescription("IDS_REGEXFUNCTOID_DESCRIPTION");
            SetBitmap("IDS_REGEXFUNCTOID_BITMAP");

            //category for this functoid. This functoid goes under the String Functoid Tab in the
            this.Category = FunctoidCategory.String;

            // Set the limits for the number of input parameters. This example: 1 parameter
            this.SetMinParams(2);
            this.SetMaxParams(2);

            // Add one line of code as set out below for each input param. For multiple input params, each line would be identical.
            AddInputConnectionType(ConnectionType.AllExceptRecord); //first input
            AddInputConnectionType(ConnectionType.AllExceptRecord); //second input

            // The functoid output can go to any node type.
            this.OutputConnectionType = ConnectionType.AllExceptRecord;

            // Set the function name that is to be called when invoking this functoid.
            // To test the map in Visual Studio, this functoid does not need to be in the GAC.
            // If using this functoid in a deployed BizTalk app. then it must be in the GAC
            //SetExternalFunctionName(GetType().Assembly.FullName, GetType().FullName, "PadLeftText");

            SetScriptBuffer(ScriptType.CSharp, this.GetCSharpBuffer());
            HasSideEffects = false;
        }

        private string GetCSharpBuffer()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("private bool RegexComparer(string initialString, string pattern)\n");
            builder.Append("{\n");
            builder.Append("\treturn Regex.IsMatch(initialString, pattern);\n");
            builder.Append("\t}\n");
            return builder.ToString();
        }

        private bool RegexComparer(string initialString, string pattern)
        {
            return Regex.IsMatch(initialString, pattern);
        }

    }
}
