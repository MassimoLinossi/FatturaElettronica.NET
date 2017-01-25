﻿using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class StabileOrganizzazioneValidator 
        : BaseTestClass<FatturaElettronica.Common.StabileOrganizzazione, FatturaElettronica.Validators.StabileOrganizzazioneValidator>
    {
        [TestInitialize]
        public new void Init()
        {
            base.Init();

            // Make sure the instance is not Empty (IsEmpty() returns false)
            challenge.NumeroCivico = "1";
        }
        [TestMethod]
        public void StabileOrganizzazioneIsNotRequiredSoLetItBeEmpty()
        {
            // For this test we want the instance to be Empty (IsEmpty() returns true)
            challenge.NumeroCivico = null;

            // When instance is Empty no validation on its properties is performed
            var r = validator.Validate(challenge);
            Assert.IsTrue(r.IsValid);
        }
        [TestMethod]
        public void IndirizzoCannotBeEmpty()
        {
            challenge.NumeroCivico = "k";
            challenge.Indirizzo = null;
            validator.ShouldHaveValidationErrorFor(x => x.Indirizzo, challenge);
            challenge.Indirizzo = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.Indirizzo, challenge);
        }
        [TestMethod]
        public void IndirizzoMinMaxLength()
        {
            challenge.Indirizzo = new string('x', 61);
            validator.ShouldHaveValidationErrorFor(x => x.Indirizzo, challenge);
            challenge.Indirizzo = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.Indirizzo, challenge);
            challenge.Indirizzo = new string('x', 60);
            validator.ShouldNotHaveValidationErrorFor(x => x.Indirizzo, challenge);
        }
        [TestMethod]
        public void NumeroCivicoMinMaxLength()
        {
            challenge.NumeroCivico = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.NumeroCivico, challenge);
            challenge.NumeroCivico = new string('x', 9);
            validator.ShouldHaveValidationErrorFor(x => x.NumeroCivico, challenge);
            challenge.NumeroCivico = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.NumeroCivico, challenge);
            challenge.NumeroCivico = new string('x', 8);
            validator.ShouldNotHaveValidationErrorFor(x => x.NumeroCivico, challenge);
        }
        [TestMethod]
        public void CAPCannotBeEmpty()
        {
            challenge.CAP = null;
            validator.ShouldHaveValidationErrorFor(x => x.CAP, challenge);
            challenge.CAP = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.CAP, challenge);
        }
        [TestMethod]
        public void CAPMinMaxLength()
        {
            challenge.CAP = new string('x', 1);
            validator.ShouldHaveValidationErrorFor(x => x.CAP, challenge);
            challenge.CAP = new string('x', 6);
            validator.ShouldHaveValidationErrorFor(x => x.CAP, challenge);
            challenge.CAP = new string('x', 5);
            validator.ShouldNotHaveValidationErrorFor(x => x.CAP, challenge);
        }
        [TestMethod]
        public void ComuneCannotBeEmpty()
        {
            challenge.Comune = null;
            validator.ShouldHaveValidationErrorFor(x => x.Comune, challenge);
            challenge.Comune = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.Comune, challenge);
        }
        [TestMethod]
        public void ComuneMinMaxLength()
        {
            challenge.Comune = new string('x', 61);
            validator.ShouldHaveValidationErrorFor(x => x.Comune, challenge);
            challenge.Comune = new string('x', 1);
            validator.ShouldNotHaveValidationErrorFor(x => x.Comune, challenge);
            challenge.Comune = new string('x', 60);
            validator.ShouldNotHaveValidationErrorFor(x => x.Comune, challenge);
        }
        [TestMethod]
        public void ProvinciaCanBeEmpty()
        {
            challenge.Provincia = null;
            validator.ShouldNotHaveValidationErrorFor(x => x.Provincia, challenge);
            challenge.Provincia = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(x => x.Provincia, challenge);
        }
        [TestMethod]
        public void ProvinciaCanOnlyAcceptDomainValues()
        {
            challenge.Provincia = "XX";
            validator.ShouldHaveValidationErrorFor(x => x.Provincia, challenge);
            challenge.Provincia = "RA";
            validator.ShouldNotHaveValidationErrorFor(x => x.Provincia, challenge);
        }
        [TestMethod]
        public void NazioneCannotBeEmpty()
        {
            challenge.Nazione = null;
            validator.ShouldHaveValidationErrorFor(x => x.Nazione, challenge);
            challenge.Nazione = string.Empty;
            validator.ShouldHaveValidationErrorFor(x => x.Nazione, challenge);
        }
        [TestMethod]
        public void NazioneCanOnlyAcceptDomainValues()
        {
            challenge.Nazione = "XX";
            validator.ShouldHaveValidationErrorFor(x => x.Nazione, challenge);
            challenge.Nazione = "IT";
            validator.ShouldNotHaveValidationErrorFor(x => x.Nazione, challenge);
        }
    }
}
