using Microsoft.BizTalk.BaseFunctoids;
using System.Reflection;
using System.Globalization;
using System.Resources;
using System;
using System.Text;

namespace BizTalk.Datetime.Functoids
{
	public class AddDaysToDate : BaseFunctoid
	{
		public AddDaysToDate() : base()
		{
			// ID for this functoid
			this.ID = 11301;

			// resource assembly must be ProjectName.ResourceName if building with VS.Net
			SetupResourceAssembly("BizTalk.Datetime.Functoids.GetCurrentDateResources", Assembly.GetExecutingAssembly());

			// Setup the Name, ToolTip, Help Description, and the Bitmap for this functoid
			SetName("IDS_ADDDAYSTODATEFUNCTOID_NAME");
			SetTooltip("IDS_ADDDAYSTODATEFUNCTOID_TOOLTIP");
			SetDescription("IDS_ADDDAYSTODATEFUNCTOID_DESCRIPTION");
			SetBitmap("IDS_ADDDAYSTODATEFUNCTOID_BITMAP");

			// Set the limits for the number of input parameters.
			// Minimum and maximum parameters that the functoid accepts 
			this.SetMinParams(3);
			this.SetMaxParams(3);

			// Category for this functoid. This functoid goes under the String Functoid Tab in the
			// VS.Net toolbox for functoids.
			this.Category = FunctoidCategory.DateTime;

			// Add one line of code as set out below for each input param. For multiple input params, each line would be identical.
			AddInputConnectionType(ConnectionType.AllExceptRecord); //first input

			// The functoid output can go to any node type.
			this.OutputConnectionType = ConnectionType.AllExceptRecord;


			// Set the function name that is to be called when invoking this functoid.
			// To test the map in Visual Studio, this functoid does not need to be in the GAC.
			// If using this functoid in a deployed BizTalk app. then it must be in the GAC
			//SetExternalFunctionName(GetType().Assembly.FullName, GetType().FullName, "GetCurrentDate");

			SetScriptBuffer(ScriptType.CSharp, this.GetCSharpBuffer());
			HasSideEffects = false;
		}

		public string AddDaysToADate(string date, int days, string format)
		{
			DateTime dt;
			if (DateTime.TryParseExact(date, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
				return dt.AddDays(days).ToString(format);
			return date;
		}

		private string GetCSharpBuffer()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("public string AddDaysToADate(string date, int days, string format)\n");
			builder.Append("{\n");
			builder.Append("\t DateTime dt;\n");
			builder.Append("\t if (DateTime.TryParseExact(date, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))\n");
			builder.Append("\t\t return dt.AddDays(days).ToString(format);\n");
			builder.Append("\t return date;\n");
			builder.Append("}\n");
			return builder.ToString();
		}
	}
}