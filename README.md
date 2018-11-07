# BizTalk Mapper Extensions UtilityPack
BizTalk Mapper Extensions UtilityPack is a set of libraries with several useful functoids to include and use it in a map, which will provide an extension of BizTalk Mapper capabilities.

## Functoids
### Conversion Functoids

* **Convert from human readable to epoch date Functoid**: This functoid allows you to convert a traditional date (Human Readable Date) into a unix date (Epoch Date).
* **Convert from epoch to human readable date Functoid** This functoid allows you to convert a unix date (Epoch Date) into a traditional date (Human Readable Date).
* **Convert datetime format Functoid**: This functoid allows you to convert datetime format.
* **Convert to a Number Functoid**: This functoid allows you to convert a string to a number (integer).

### Dynamic Generators Functoids

* **Password Generator Functoid**: Use this functoid to build a random password.
* **Guid Generator Functoid**: This functoid allows you to generate a new Guid.
* **Tiny Id Generator Functoid**: This functoid allows you to generate a new Tiny Id.

### Encoder Functoids

* **Base64 Decoder Functoid**: This functoid allows you to decode Base64-encoded text strings.
* **Base64  Encoder FunctoidP**: This functoid allows you to convert string object into base64 encoded string.

### Configuration Functoids

* **BTSNTSvc Config Get Functoid**: This functoid allows you to get configuration parameters from BTSNTsvc.exe.config. If there is no section specified, the functoid reads from the AppSettings.
* **System Environment Variable Get Functoid**: This functoid allows you to get configuration parameters from machine System Environment Variable.
* **Custom Config Get Functoid**: This functoid allows you to get configuration parameters from a custom configuration file.
* **Windows Registry Config Get Functoid**: This functoid allows you to get configuration parameters from Windows Registry.
* **SSO Config Get Functoid**: This functoid allows you to get configuration parameters from SSO Database.
* **Rule Engine Config Get Functoid**: This functoid allows you to obtain a definition value from a Vocabulary in the Business Rules Engine.

### CRM Functoids

* **CRM Lookup Functoid**: This functoid allows you to retrieve a value from CRM lookup field. This functoid is able to performs lookup operation using two different approach: Accessing the CRM database (read-only), for local CRM integration or through the CRM web services if you want avoid giving access to the database or if you have to integrate CRM online.
* **MSCRM Map Helper Base Types Functoid**: Use this functoid when you want map CRM base data types such as “xs:string”, “xs:int” and so on.
* **MSCRM Map Helper Guid Functoid**: Use this functoid when you want map CRM guid type.
* **MSCRM Map Helper Money Functoid**: Use this functoid when you want map CRM money type.
* **MSCRM Map Helper Option Value Functoid**: Use this functoid when you want map CRM option value type.
* **MSCRM Map Helper References Functoid**: Use this functoid when you want map CRM reference type.

### String Functoids

* **String Constant functoid**: This functoid allows you to set constant values (strings) inside de maps.
* **String ToTitleCase functoid**: This functoid allows you to Converts the specified string to title case (except for words that are entirely in uppercase, which are considered to be acronyms).
* **String Advance Compare Functoid**: This functoid allows you to compare two specified String objects, ignoring or honoring their case, and returns an boolean that indicates if they are equal or not.
* **String Replace Functoid**: This functoid returns a new string in which all occurrences of a specified string (second parameter) found in the first string are replaced with another specified string (third parameter).
* **String Normalize Functoid**: This functoid allows you to normalize the text. It will remove two or more consecutive spaces and replace them with a single space, remove two or more consecutive newlines and replace them with a single newline and "condense" multiple tabs into one.
* **String PadLeft Functoid**: This functoid allows you to set a new string that right-aligns the characters in this instance by padding them on the left with a specified Unicode character, for a specified total length.
* **String PadRight Functoid**: This functoid allows you to set a new string that left-aligns the characters in this string by padding them on the right with a specified Unicode character, for a specified total length.
* **String Remove Leading Zeros Functoid**: This functoid allows you to remove any leading zeros from an input string.

### Custom Advanced Functoids

* **Default Value Mapping functoid**: The Default Value Mapping have a simillar but different behaviour. You can use the Default Value Mapping functoid to return a value from one of two input parameters. If the value of the first input parameter is Null or Empty, then the value of the second input parameter is returned, otherwise the first input is returned.

### XPath Functoids

* **XPath Functoid**: This functoid natively integrates custom XPath queries in the BizTalk mapper

### SharePoint Functoids

* **Add SharePoint 2013 Document Set Functoid**: Creates a Document Set in an existing SharePoint 2013 List. 

### Logical Functoids

* **Advance Logical AND Functoid**: Use the Advance Logical AND functoid to return the logical AND of input parameters. This functoid requires two to one hundred input parameters.
* **Advance Equal Functoid**: Use the Advance Equal functoid to return the value "true" if the first input parameter is equal to the second input parameter. This functoid requires two input parameters.
* **Advance Greater Than Functoid**: Use the Advance Greater Than functoid to return the value "true" if the first input parameter is greater than the second input parameter. This functoid requires two input parameters.
* **Advance Greater Than or Equal To Functoid**: Use the Advance Greater Than or Equal To functoid to return the value "true" if the first input parameter is greater than or equal to the second input parameter. This functoid requires two input parameters.
* **Advance Less Than Functoid**: Use the Advance Less Than functoid to return the value "true" if the first input parameter is less than the second input parameter. This functoid requires two input parameters.
* **Advance Less Than or Equal To Functoid**: Use the Advance Less Than or Equal To functoid to return the value "true" if the first input parameter is less than or equal to the second input parameter. This functoid requires two input parameters.
* **Advance Not Equal Functoid**: Use the Advance Not Equal functoid to return the value “true” if the first input parameter is not equal to the second input parameter. This functoid requires two input parameters.
* **Advance Logical NOT Functoid**: Use the Advance Logical NOT functoid to return the logical inversion of the input parameter. This functoid requires one input parameter only.
* **Advance Logical OR Functoid**: Use the Advance Logical OR functoid to return the logical OR of input parameters. The input parameters have to be Boolean or numeric. This functoid requires two to one hundred input parameters.
* **If-Then-Else Functoid**: Use the If-Then-Else Functoid to return a value from one of two input parameters based on a condition. If the condition (first input) is True, then the value of the second input parameter is returned, otherwise the Third input is returned.

### Database Functoids

* **Adv Database Lookup Functoid**: Use the Adv Database Lookup functoid to extract information from a database and store it as a Microsoft ActiveX Data Objects (ADO) recordset. This functoid requires the following 2 inputs: a database connection string and a WHERE clausure.
* **Adv Value Extractor** Use the Adv Value Extrator functoid to extract the appropriate column value from a recordset returned by the Database Lookup functoid. This functoid requires two inputs parameters: a link to the Database Lookup functoid and a column name.

### Math Functoids

* **Negate Number Functoid**: Use Negate Functoif to return the input double as its negated form. If it's positive, it will return as negative and vice-versa.
* **SmartRound Functoid** Use SmartRound to return the rounded double, by the second parameter input.