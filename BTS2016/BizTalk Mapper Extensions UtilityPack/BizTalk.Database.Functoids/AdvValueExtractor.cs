using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.BizTalk.BaseFunctoids;
using System.Reflection;

namespace BizTalk.Database.Functoids
{
    [Serializable]
    public class AdvValueExtractor : BaseFunctoid
    {
        public AdvValueExtractor()
            : base()
        {
            //ID for this functoid
            this.ID = 11201;

            SetupResourceAssembly("BizTalk.Database.Functoids.DatabaseResources", Assembly.GetExecutingAssembly());

            //Setup the Name, ToolTip, Help Description, and the Bitmap for this functoid
            SetName("IDS_ADVDBVALUEEXTFUNCTOID_NAME");
            SetTooltip("IDS_ADVDBVALUEEXTFUNCTOID_TOOLTIP");
            SetDescription("IDS_ADVDBVALUEEXTFUNCTOID_DESCRIPTION");
            SetBitmap("IDS_ADVDBVALUEEXTFUNCTOID_BITMAP");

            //category for this functoid. This functoid goes under the String Functoid Tab in the
            this.Category = FunctoidCategory.DatabaseExtract;

            // Set the limits for the number of input parameters. This example: 1 parameter
            this.SetMinParams(2);
            this.SetMaxParams(2);

            // Add one line of code as set out below for each input param. For multiple input params, each line would be identical.
            AddInputConnectionType(ConnectionType.FunctoidDatabaseLookup); //first input
            AddInputConnectionType(ConnectionType.AllExceptRecord);

            // The functoid output can go to any node type.
            this.OutputConnectionType = ConnectionType.AllExceptRecord;

            // Set the function name that is to be called when invoking this functoid.
            // To test the map in Visual Studio, this functoid does not need to be in the GAC.
            // If using this functoid in a deployed BizTalk app. then it must be in the GAC
            SetExternalFunctionName(GetType().Assembly.FullName, "BizTalk.Database.Functoids.DBFunctoidScripts", "AdvDBValueExtract");
            base.HasSideEffects = true;
        }
    }
}
