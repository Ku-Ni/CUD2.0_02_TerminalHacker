using System;
using System.Collections.Generic;
using System.Xml.Serialization;

// http://wiki.unity3d.com/index.php?title=Saving_and_Loading_Data:_XmlSerializer
[XmlRoot("PasswordCollection")]
public class PasswordsContainer
{
    [XmlArray("Passwords")]
    [XmlArrayItem("Password")]
    public List<Password> passwords;

}
