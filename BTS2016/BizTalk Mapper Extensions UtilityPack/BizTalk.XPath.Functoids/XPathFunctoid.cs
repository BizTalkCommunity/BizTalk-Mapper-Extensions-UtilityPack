﻿/******************************************************************************************************************
 * Name:           XPathFunctoid
 * Description:    Functoid to natively embed XPath expressions in the XSLT generated by the BizTalk Mapper.
 * Compatibility:  BizTalk Server 2013 R2
 * Author:         Martijn Schiedon / ValueBlue B.V. / The Netherlands
 * Creation Date:  2014-11-13
 * Version:        1.0.0.0
 ******************************************************************************************************************/

using Microsoft.BizTalk.BaseFunctoids;

namespace ValueBlue.BizTalk.MapperExtensions {
    public class XPathFunctoid : BaseFunctoid {
        /// <summary>
        /// This functoid natively integrates custom XPath queries in the BizTalk mapper.
        /// </summary>
        /// <remarks>
        /// The first parameter specifies an absolute or relative XPath expression, which becomes a native part of the generated XSLT.
        /// The (optional) second parameter is a link to the source tree node that becomes the (looping) context for the XPath expression.
        /// The functoid output can be linked to a destination schema node or serve as input to other functoids.
        /// </remarks>
        public XPathFunctoid() : base() {
            // The unique identifier for the functoid uses the Microsoft-reserved identifier for this type of functoid.
            base.ID = (int)BaseFunctoidIDs.XPath;

            // Set up the string and bitmap resources for this functoid.
            base.SetupResourceAssembly("ValueBlue.BizTalk.MapperExtensions.Resources", GetType().Assembly);

            // Set the name, description and bitmap Visual Studio and the mapper will display.
            base.SetName("IDS_XPATHFUNCTOID_NAME");
            base.SetTooltip("IDS_XPATHFUNCTOID_TOOLTIP");
            base.SetDescription("IDS_XPATHFUNCTOID_DESCRIPTION");
            base.SetBitmap("IDB_XPATHFUNCTOID");

            // This "for internal use only" category triggers the mapper to emit valid XPath expressions in the XSLT.
            base.Category = FunctoidCategory.XPath;

            // The functoid has a fixed number of inputs, the first mandatory, the second optional
            base.HasVariableInputs = false;
            base.SetMinParams(1);
            base.SetMaxParams(2);

            // Anything that produces a string containing an XPath expression is valid as input.
            // The daredevils insisting to use a record with link type "Copy text and sub content value" can prepend a string functoid.
            base.AddInputConnectionType(ConnectionType.AllExceptRecord);

            // The mapper implements looping if the second parameter is connected to a repeating record (or a field
            // within a repeating record) in the source schema. An added bonus is that this record becomes the current
            // context for the XPath expression.
            base.AddInputConnectionType(ConnectionType.Record | ConnectionType.Field);

            // The output of this functoid cannot be linked to records.
            base.OutputConnectionType = ConnectionType.AllExceptRecord;

            // Native XPath expressions do not have any side effects.
            base.HasSideEffects = false;
        }
    }
}