using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using mspr;


public class ValidationFormTests 
{
    [Test]
    public void validNickname_Test()
    {
    	Assert.AreEqual(FormUtils.validNickname(""), false);
    	Assert.AreEqual(FormUtils.validNickname("Thibaut"), true);

    }

    [Test]
    public void validEmail_Test()
    {
    	Assert.AreEqual(FormUtils.validEmail(""), false);
    	Assert.AreEqual(FormUtils.validEmail("badmail.test"), false);
    	Assert.AreEqual(FormUtils.validEmail("thibaut@epsi.fr"), true);

    }
}
