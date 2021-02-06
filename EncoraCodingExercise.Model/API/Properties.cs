﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EncoraCodingExercise.Model
{
   public class Properties
    {

        public class Rootobject
        {
            public IEnumerable<Property> properties { get; set; }
        }

        public class Property
        {
            public int id { get; set; }
            public int accountId { get; set; }
            public int? buyerAccountId { get; set; }
            public int? buyerUserId { get; set; }
            public object externalId { get; set; }
            public object programId { get; set; }
            public bool isDwellCertified { get; set; }
            public bool isAllowOffer { get; set; }
            public bool isAllowPreview { get; set; }
            public bool isFeatured { get; set; }
            public bool isRentGuaranteed { get; set; }
            public bool allowRentGuaranteedOptout { get; set; }
            public bool isSecuritized { get; set; }
            public bool isHot { get; set; }
            public bool isNew { get; set; }
            public bool? isBargain { get; set; }
            public bool isDiligenceVaultUnlocked { get; set; }
            public bool? isPropertyManagerOfferRetain { get; set; }
            public bool? isHoa { get; set; }
            public bool hasAudio { get; set; }
            public bool hasDiligenceVaultDocuments { get; set; }
            public int market { get; set; }
            public int? daysOnMarket { get; set; }
            public float? latitude { get; set; }
            public float? longitude { get; set; }
            public object propertyName { get; set; }
            public string description { get; set; }
            public object highlights { get; set; }
            public string mainImageUrl { get; set; }
            public object personalProperties { get; set; }
            public string diligenceVaultSummary { get; set; }
            public object featuredReason { get; set; }
            public string status { get; set; }
            public string allowedFundingTypes { get; set; }
            public string allowableSaleTypes { get; set; }
            public string visibility { get; set; }
            public string priceVisibility { get; set; }
            public string propertyType { get; set; }
            public string certificationLevel { get; set; }
            public DateTime? escrowClosingDate { get; set; }
            public Address address { get; set; }
            public Financial financial { get; set; }
            public Physical physical { get; set; }
            public Score score { get; set; }
            public Valuation valuation { get; set; }
            public Resources resources { get; set; }
            public object manager { get; set; }
            public object seller { get; set; }
            public object sellerBroker { get; set; }
            public object hoa { get; set; }
            public Lease lease { get; set; }
            public object[] diligences { get; set; }
            public Googlemapoption googleMapOption { get; set; }
            public object inspectionType { get; set; }
        }

        public class Address
        {
            public string address1 { get; set; }
            public string address2 { get; set; }
            public string city { get; set; }
            public string country { get; set; }
            public string county { get; set; }
            public object district { get; set; }
            public string state { get; set; }
            public string zip { get; set; }
            public string zipPlus4 { get; set; }
        }

        public class Financial
        {
            public object capRate { get; set; }
            public string occupancy { get; set; }
            public bool isSection8 { get; set; }
            public DateTime leaseStartDate { get; set; }
            public DateTime leaseEndDate { get; set; }
            public float listPrice { get; set; }
            public object salePrice { get; set; }
            public object marketValue { get; set; }
            public object monthlyHoa { get; set; }
            public object monthlyManagementFees { get; set; }
            public float monthlyRent { get; set; }
            public object netYield { get; set; }
            public object turnOverFee { get; set; }
            public object rehabCosts { get; set; }
            public object rehabDate { get; set; }
            public float? yearlyInsuranceCost { get; set; }
            public float yearlyPropertyTaxes { get; set; }
            public bool isCashOnly { get; set; }
        }

        public class Physical
        {
            public float bathRooms { get; set; }
            public float bedRooms { get; set; }
            public string parcelNumber { get; set; }
            public bool isPool { get; set; }
            public int? lotSize { get; set; }
            public int squareFeet { get; set; }
            public object stories { get; set; }
            public object units { get; set; }
            public int yearBuilt { get; set; }
            public object zipYearBuilt { get; set; }
        }

        public class Score
        {
            public object conditionScore { get; set; }
            public string crimeScore { get; set; }
            public int neighborhoodScore { get; set; }
            public object overallScore { get; set; }
            public object qualityScore { get; set; }
            public string schoolScore { get; set; }
            public string charterSchoolScore { get; set; }
            public string floodRiskScore { get; set; }
            public object walkabilityScore { get; set; }
        }

        public class Valuation
        {
            public object avmBpoValue { get; set; }
            public object avmBpoAdjValue { get; set; }
            public object avmBpoDate { get; set; }
            public float rsAvmValue { get; set; }
            public object rsAvmDate { get; set; }
            public float? rsBpoMergeValue { get; set; }
        }

        public class Resources
        {
            public Photo[] photos { get; set; }
            public Floorplan[] floorPlans { get; set; }
            public Threedrendering[] threeDRenderings { get; set; }
            public object[] audios { get; set; }
        }

        public class Photo
        {
            public int id { get; set; }
            public string guid { get; set; }
            public string resourceType { get; set; }
            public bool isPublic { get; set; }
            public object description { get; set; }
            public string filename { get; set; }
            public object sizeInByte { get; set; }
            public string contentType { get; set; }
            public string url { get; set; }
            public string urlMedium { get; set; }
            public string urlSmall { get; set; }
            public object textContent { get; set; }
        }

        public class Floorplan
        {
            public int id { get; set; }
            public string guid { get; set; }
            public string resourceType { get; set; }
            public bool isPublic { get; set; }
            public object description { get; set; }
            public string filename { get; set; }
            public object sizeInByte { get; set; }
            public string contentType { get; set; }
            public string url { get; set; }
            public string urlMedium { get; set; }
            public string urlSmall { get; set; }
            public object textContent { get; set; }
        }

        public class Threedrendering
        {
            public int id { get; set; }
            public string guid { get; set; }
            public string resourceType { get; set; }
            public bool isPublic { get; set; }
            public object description { get; set; }
            public string filename { get; set; }
            public object sizeInByte { get; set; }
            public string contentType { get; set; }
            public string url { get; set; }
            public object urlMedium { get; set; }
            public object urlSmall { get; set; }
            public object textContent { get; set; }
        }

        public class Lease
        {
            public Leasesummary leaseSummary { get; set; }
            public Utilitiesownership utilitiesOwnership { get; set; }
            public Applianceownership applianceOwnership { get; set; }
        }

        public class Leasesummary
        {
            public string occupancy { get; set; }
            public object leasingStatus { get; set; }
            public object marketedRent { get; set; }
            public string paymentStatus { get; set; }
            public DateTime leaseStartDate { get; set; }
            public DateTime leaseEndDate { get; set; }
            public float monthlyRent { get; set; }
            public float? securityDepositAmount { get; set; }
            public object hasPet { get; set; }
            public object petFeeAmount { get; set; }
            public bool isPetsDeposit { get; set; }
            public float? petsDepositAmount { get; set; }
            public bool? isLeaseConcessions { get; set; }
            public bool isRentersInsuranceRequired { get; set; }
            public bool isSection8 { get; set; }
            public bool isTenantBackgroundChecked { get; set; }
            public bool isTenantIncomeAbove3x { get; set; }
            public object isTenantMayTerminateEarly { get; set; }
            public object isTenantPurchaseOption { get; set; }
        }

        public class Utilitiesownership
        {
            public string electric { get; set; }
            public string gas { get; set; }
            public string water { get; set; }
            public string garbage { get; set; }
            public string pool { get; set; }
            public string landscaping { get; set; }
            public string pestControl { get; set; }
        }

        public class Applianceownership
        {
            public string refrigerator { get; set; }
            public string dishwasher { get; set; }
            public string washer { get; set; }
            public string dryer { get; set; }
            public string microwave { get; set; }
            public string stove { get; set; }
        }

        public class Googlemapoption
        {
            public bool hasStreetView { get; set; }
            public int povHeading { get; set; }
            public int povPitch { get; set; }
            public float povLatitude { get; set; }
            public float povLongitude { get; set; }
        }

    }
}