using Microsoft.BizTalk.BaseFunctoids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BizTalk.String.Functoids
{
    [Serializable]
    class StringSplitter : BaseFunctoid
    {

        public StringSplitter()
            : base()
        {
            //ID for this functoid
            this.ID = 10007;

            // resource assembly must be ProjectName.ResourceName if building with VS.Net
            SetupResourceAssembly("BizTalk.String.Functoids.StringResources", Assembly.GetExecutingAssembly());

            //Setup the Name, ToolTip, Help Description, and the Bitmap for this functoid
            SetName("IDS_STRINGSPLITTERFUNCTOID_NAME");
            SetTooltip("IDS_STRINGSPLITTERFUNCTOID_TOOLTIP");
            SetDescription("IDS_STRINGSPLITTERFUNCTOID_DESCRIPTION");
            SetBitmap("IDS_STRINGSPLITTERFUNCTOID_BITMAP");

            //category for this functoid. This functoid goes under the String Functoid Tab in the
            this.Category = FunctoidCategory.String;

            // Set the limits for the number of input parameters. This example: 1 parameter
            this.SetMinParams(3);
            this.SetMaxParams(3);

            // Add one line of code as set out below for each input param. For multiple input params, each line would be identical.
            AddInputConnectionType(ConnectionType.AllExceptRecord); //first input
            AddInputConnectionType(ConnectionType.AllExceptRecord); //Second input
            AddInputConnectionType(ConnectionType.AllExceptRecord); //Third input

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
            builder.Append("private string SplitString(string initialString, char splitter, int position)\n");
            builder.Append("{\n");
            builder.Append("\tstring[] array = initialString.Split(splitter);\n");
            builder.Append("\t\t\n");
            builder.Append("\t\tposition -= 1;\n");
            builder.Append("\t\t\n");
            builder.Append("\tif(position > array.Count())\n");
            builder.Append("\treturn string.Empty;\n");
            builder.Append("\t\t\n");
            builder.Append("\t\treturn array[position];\n");
            builder.Append("\t}\n");
            return builder.ToString();
        }

        private string SplitString(string initialString, char splitter, int position)
        {
            string[] array = initialString.Split(splitter);
            position -= 1;
            if (position > array.Count())
                return string.Empty;

            return array[position];
        }
    }
}
