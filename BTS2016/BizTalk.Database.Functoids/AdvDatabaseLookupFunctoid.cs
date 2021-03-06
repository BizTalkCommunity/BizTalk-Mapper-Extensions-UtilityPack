using Microsoft.BizTalk.BaseFunctoids;
using System.Reflection;
using System.Globalization;
using System.Resources;
using System;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace BizTalk.Database.Functoids
{
	public class AdvDatabaseLookupFunctoid : BaseFunctoid
	{
        [ThreadStatic]
        private static Hashtable myDBFunctoidHelperList;

        public AdvDatabaseLookupFunctoid()
            : base()
        {
            //ID for this functoid
            this.ID = 11200;

            // resource assembly must be ProjectName.ResourceName if building with VS.Net
            SetupResourceAssembly("BizTalk.Database.Functoids.DatabaseResources", Assembly.GetExecutingAssembly());

            //Setup the Name, ToolTip, Help Description, and the Bitmap for this functoid
            SetName("IDS_ADVDBLOOKUPFUNCTOID_NAME");
            SetTooltip("IDS_ADVDBLOOKUPFUNCTOID_TOOLTIP");
            SetDescription("IDS_ADVDBLOOKUPFUNCTOID_DESCRIPTION");
            SetBitmap("IDS_ADVDBLOOKUPFUNCTOID_BITMAP");

            //category for this functoid. This functoid goes under the String Functoid Tab in the
            this.Category = FunctoidCategory.DatabaseLookup;

            // Set the limits for the number of input parameters. This example: 1 parameter
            this.SetMinParams(3);
            this.SetMaxParams(3);

            // Add one line of code as set out below for each input param. For multiple input params, each line would be identical.
            AddInputConnectionType(ConnectionType.AllExceptRecord); //first input
            AddInputConnectionType(ConnectionType.AllExceptRecord); //Second input
            AddInputConnectionType(ConnectionType.AllExceptRecord);

            // The functoid output can go to any node type.
            this.OutputConnectionType = ConnectionType.FunctoidDatabaseExtract;

            // Set the function name that is to be called when invoking this functoid.
            // To test the map in Visual Studio, this functoid does not need to be in the GAC.
            // If using this functoid in a deployed BizTalk app. then it must be in the GAC
            SetExternalFunctionName(GetType().Assembly.FullName, "BizTalk.Database.Functoids.DBFunctoidScripts", "AdvDBLookup");
            SetExternalFunctionName2("AdvDBLookupShutdown");

            base.HasSideEffects = true;
        }
    }
}