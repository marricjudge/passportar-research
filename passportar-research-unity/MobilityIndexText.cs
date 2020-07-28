using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobilityIndexText : MonoBehaviour
{
    public Text mobilityDigitText;
    public Text rankDigitText;
    private LoadPassportData LoadPassportDataContr;
    private ChangeSceneOnCountryTouch ChangeSceneOnCountryTouchContr;
    private List<int> PassportPowerDataList = new List<int>();
    private List<int> PassportRankDataList = new List<int>();
    public string detectedCountryName;
    private string receivedNat;
    private int countryIdentifier;
    private int printablePassportPowerNumber;
    private int currentNationalityInt;
    private int scanCountryIdent;

    public void Awake()
    {
        LoadPassportDataContr = GameObject.FindObjectOfType<LoadPassportData>();
        ChangeSceneOnCountryTouchContr = GameObject.FindObjectOfType<ChangeSceneOnCountryTouch>();
    }

    public void catchNationalityInt(int nationalityInt) //Gets the recognised passport int from AugmendImageVisualizer.cs
    {
        currentNationalityInt = nationalityInt;
    }

    private void Start()
    {
        mobilityDigitText.text = PassportPowerDataList[currentNationalityInt].ToString();
        rankDigitText.text = "#" + PassportRankDataList[currentNationalityInt].ToString();
    }

    void Update()
    {
        detectedCountryName = ChangeSceneOnCountryTouchContr.catchClickedCountry();
        PassportPowerDataList = LoadPassportDataContr.sendPassportPowerList();
        PassportRankDataList = LoadPassportDataContr.sendPassportRankList();
        setCountryIdentifier();

        int IsTracked = PlayerPrefs.GetInt("IsTracked");

        receivedNat = PlayerPrefs.GetString("savedNationality");
        setScanCountryIdent();

        if (detectedCountryName == "EMPTY" || detectedCountryName == "EARTH_MESH" || detectedCountryName == "EARTH_MESH_map")
        {
            mobilityDigitText.text = PassportPowerDataList[scanCountryIdent].ToString();
            rankDigitText.text = "#" + PassportRankDataList[scanCountryIdent].ToString();
        } else
        {
            mobilityDigitText.text = PassportPowerDataList[countryIdentifier].ToString();
            rankDigitText.text = "#" + PassportRankDataList[countryIdentifier].ToString();
        }
    }

    private void setScanCountryIdent()
    {
        if (receivedNat == "Afghanistan") { scanCountryIdent = 1; }
        if (receivedNat == "Albania") { scanCountryIdent = 2; }
        if (receivedNat == "Algeria") { scanCountryIdent = 3; }
        if (receivedNat == "Andorra") { scanCountryIdent = 4; }
        if (receivedNat == "Angola") { scanCountryIdent = 5; }
        if (receivedNat == "Antigua & Barbuda") { scanCountryIdent = 6; }
        if (receivedNat == "Argentina") { scanCountryIdent = 7; }
        if (receivedNat == "Armenia") { scanCountryIdent = 8; }
        if (receivedNat == "Australia") { scanCountryIdent = 9; }
        if (receivedNat == "Austria") { scanCountryIdent = 10; }
        if (receivedNat == "Azerbaijan") { scanCountryIdent = 11; }
        if (receivedNat == "Bahamas") { scanCountryIdent = 12; }
        if (receivedNat == "Bahrain") { scanCountryIdent = 13; }
        if (receivedNat == "Bangladesh") { scanCountryIdent = 14; }
        if (receivedNat == "Barbados") { scanCountryIdent = 15; }
        if (receivedNat == "Belarus") { scanCountryIdent = 16; }
        if (receivedNat == "Belgium") { scanCountryIdent = 17; }
        if (receivedNat == "Belize") { scanCountryIdent = 18; }
        if (receivedNat == "Benin") { scanCountryIdent = 19; }
        if (receivedNat == "Bhutan") { scanCountryIdent = 20; }
        if (receivedNat == "Bolivia") { scanCountryIdent = 21; }
        if (receivedNat == "Bosnia & Herzegovina") { scanCountryIdent = 22; }
        if (receivedNat == "Botswana") { scanCountryIdent = 23; }
        if (receivedNat == "Brazil") { scanCountryIdent = 24; }
        if (receivedNat == "Brunei") { scanCountryIdent = 25; }
        if (receivedNat == "Bulgaria") { scanCountryIdent = 26; }
        if (receivedNat == "Burkina Faso") { scanCountryIdent = 27; }
        if (receivedNat == "Burundi") { scanCountryIdent = 28; }
        if (receivedNat == "Cambodia") { scanCountryIdent = 29; }
        if (receivedNat == "Cameroon") { scanCountryIdent = 30; }
        if (receivedNat == "Canada") { scanCountryIdent = 31; }
        if (receivedNat == "Cape Verde") { scanCountryIdent = 32; }
        if (receivedNat == "Central African Republic") { scanCountryIdent = 33; }
        if (receivedNat == "Chad") { scanCountryIdent = 34; }
        if (receivedNat == "Chile") { scanCountryIdent = 35; }
        if (receivedNat == "China") { scanCountryIdent = 36; }
        if (receivedNat == "Colombia") { scanCountryIdent = 37; }
        if (receivedNat == "Comoros") { scanCountryIdent = 38; }
        if (receivedNat == "Congo") { scanCountryIdent = 39; }
        if (receivedNat == "DR Congo") { scanCountryIdent = 40; }
        if (receivedNat == "Costa Rica") { scanCountryIdent = 41; }
        if (receivedNat == "Coted'Ivoire") { scanCountryIdent = 42; }
        if (receivedNat == "Croatia") { scanCountryIdent = 43; }
        if (receivedNat == "Cuba") { scanCountryIdent = 44; }
        if (receivedNat == "Cyprus") { scanCountryIdent = 45; }
        if (receivedNat == "Czech Republic") { scanCountryIdent = 46; }
        if (receivedNat == "Denmark") { scanCountryIdent = 47; }
        if (receivedNat == "Djibouti") { scanCountryIdent = 48; }
        if (receivedNat == "Dominica") { scanCountryIdent = 49; }
        if (receivedNat == "Dominican Republic") { scanCountryIdent = 50; }
        if (receivedNat == "Ecuador") { scanCountryIdent = 51; }
        if (receivedNat == "Egypt") { scanCountryIdent = 52; }
        if (receivedNat == "El Salvador") { scanCountryIdent = 53; }
        if (receivedNat == "Equatorial Guinea") { scanCountryIdent = 54; }
        if (receivedNat == "Eritrea") { scanCountryIdent = 55; }
        if (receivedNat == "Estonia") { scanCountryIdent = 56; }
        if (receivedNat == "Eswatini") { scanCountryIdent = 57; }
        if (receivedNat == "Ethiopia") { scanCountryIdent = 58; }
        if (receivedNat == "Fiji") { scanCountryIdent = 59; }
        if (receivedNat == "Finland") { scanCountryIdent = 60; }
        if (receivedNat == "France") { scanCountryIdent = 61; }
        if (receivedNat == "Gabon") { scanCountryIdent = 62; }
        if (receivedNat == "Gambia") { scanCountryIdent = 63; }
        if (receivedNat == "Georgia") { scanCountryIdent = 64; }
        if (receivedNat == "Germany") { scanCountryIdent = 65; }
        if (receivedNat == "Ghana") { scanCountryIdent = 66; }
        if (receivedNat == "Greece") { scanCountryIdent = 67; }
        if (receivedNat == "Grenada") { scanCountryIdent = 68; }
        if (receivedNat == "Guatemala") { scanCountryIdent = 69; }
        if (receivedNat == "Guinea") { scanCountryIdent = 70; }
        if (receivedNat == "Guinea-Bissau") { scanCountryIdent = 71; }
        if (receivedNat == "Guyana") { scanCountryIdent = 72; }
        if (receivedNat == "Haiti") { scanCountryIdent = 73; }
        if (receivedNat == "Honduras") { scanCountryIdent = 74; }
        if (receivedNat == "Hong Kong") { scanCountryIdent = 75; }
        if (receivedNat == "Hungary") { scanCountryIdent = 76; }
        if (receivedNat == "Iceland") { scanCountryIdent = 77; }
        if (receivedNat == "India") { scanCountryIdent = 78; }
        if (receivedNat == "Indonesia") { scanCountryIdent = 79; }
        if (receivedNat == "Iran") { scanCountryIdent = 80; }
        if (receivedNat == "Iraq") { scanCountryIdent = 81; }
        if (receivedNat == "Ireland") { scanCountryIdent = 82; }
        if (receivedNat == "Israel") { scanCountryIdent = 83; }
        if (receivedNat == "Italy") { scanCountryIdent = 84; }
        if (receivedNat == "Jamaica") { scanCountryIdent = 85; }
        if (receivedNat == "Japan") { scanCountryIdent = 86; }
        if (receivedNat == "Jordan") { scanCountryIdent = 87; }
        if (receivedNat == "Kazakhstan") { scanCountryIdent = 88; }
        if (receivedNat == "Kenya") { scanCountryIdent = 89; }
        if (receivedNat == "Kiribati") { scanCountryIdent = 90; }
        if (receivedNat == "Kosovo") { scanCountryIdent = 91; }
        if (receivedNat == "Kuwait") { scanCountryIdent = 92; }
        if (receivedNat == "Kyrgyzstan") { scanCountryIdent = 93; }
        if (receivedNat == "Laos") { scanCountryIdent = 94; }
        if (receivedNat == "Latvia") { scanCountryIdent = 95; }
        if (receivedNat == "Lebanon") { scanCountryIdent = 96; }
        if (receivedNat == "Lesotho") { scanCountryIdent = 97; }
        if (receivedNat == "Liberia") { scanCountryIdent = 98; }
        if (receivedNat == "Libya") { scanCountryIdent = 99; }
        if (receivedNat == "Liechtenstein") { scanCountryIdent = 100; }
        if (receivedNat == "Lithuania") { scanCountryIdent = 101; }
        if (receivedNat == "Luxembourg") { scanCountryIdent = 102; }
        if (receivedNat == "Macao") { scanCountryIdent = 103; }
        if (receivedNat == "Madagascar") { scanCountryIdent = 104; }
        if (receivedNat == "Malawi") { scanCountryIdent = 105; }
        if (receivedNat == "Malaysia") { scanCountryIdent = 106; }
        if (receivedNat == "Maldives") { scanCountryIdent = 107; }
        if (receivedNat == "Mali") { scanCountryIdent = 108; }
        if (receivedNat == "Malta") { scanCountryIdent = 109; }
        if (receivedNat == "Marshall Islands") { scanCountryIdent = 110; }
        if (receivedNat == "Mauritania") { scanCountryIdent = 111; }
        if (receivedNat == "Mauritius") { scanCountryIdent = 112; }
        if (receivedNat == "Mexico") { scanCountryIdent = 113; }
        if (receivedNat == "Micronesia") { scanCountryIdent = 114; }
        if (receivedNat == "Moldova") { scanCountryIdent = 115; }
        if (receivedNat == "Monaco") { scanCountryIdent = 116; }
        if (receivedNat == "Mongolia") { scanCountryIdent = 117; }
        if (receivedNat == "Montenegro") { scanCountryIdent = 118; }
        if (receivedNat == "Morocco") { scanCountryIdent = 119; }
        if (receivedNat == "Mozambique") { scanCountryIdent = 120; }
        if (receivedNat == "Myanmar") { scanCountryIdent = 121; }
        if (receivedNat == "Namibia") { scanCountryIdent = 122; }
        if (receivedNat == "Nauru") { scanCountryIdent = 123; }
        if (receivedNat == "Nepal") { scanCountryIdent = 124; }
        if (receivedNat == "Netherlands") { scanCountryIdent = 125; }
        if (receivedNat == "New Zealand") { scanCountryIdent = 126; }
        if (receivedNat == "Nicaragua") { scanCountryIdent = 127; }
        if (receivedNat == "Niger") { scanCountryIdent = 128; }
        if (receivedNat == "Nigeria") { scanCountryIdent = 129; }
        if (receivedNat == "North Korea") { scanCountryIdent = 130; }
        if (receivedNat == "North Macedonia") { scanCountryIdent = 131; }
        if (receivedNat == "Norway") { scanCountryIdent = 132; }
        if (receivedNat == "Oman") { scanCountryIdent = 133; }
        if (receivedNat == "Pakistan") { scanCountryIdent = 134; }
        if (receivedNat == "Palau") { scanCountryIdent = 135; }
        if (receivedNat == "Palestine") { scanCountryIdent = 136; }
        if (receivedNat == "Panama") { scanCountryIdent = 137; }
        if (receivedNat == "Papua New Guinea") { scanCountryIdent = 138; }
        if (receivedNat == "Paraguay") { scanCountryIdent = 139; }
        if (receivedNat == "Peru") { scanCountryIdent = 140; }
        if (receivedNat == "Philippines") { scanCountryIdent = 141; }
        if (receivedNat == "Poland") { scanCountryIdent = 142; }
        if (receivedNat == "Portugal") { scanCountryIdent = 143; }
        if (receivedNat == "Qatar") { scanCountryIdent = 144; }
        if (receivedNat == "Romania") { scanCountryIdent = 145; }
        if (receivedNat == "Russia") { scanCountryIdent = 146; }
        if (receivedNat == "Rwanda") { scanCountryIdent = 147; }
        if (receivedNat == "St Kitts & Nevis") { scanCountryIdent = 148; }
        if (receivedNat == "Saint Lucia") { scanCountryIdent = 149; }
        if (receivedNat == "Samoa") { scanCountryIdent = 150; }
        if (receivedNat == "San Marino") { scanCountryIdent = 151; }
        if (receivedNat == "Sao Tome and Principe") { scanCountryIdent = 152; }
        if (receivedNat == "Saudi Arabia") { scanCountryIdent = 153; }
        if (receivedNat == "Senegal") { scanCountryIdent = 154; }
        if (receivedNat == "Serbia") { scanCountryIdent = 155; }
        if (receivedNat == "Seychelles") { scanCountryIdent = 156; }
        if (receivedNat == "Sierra Leone") { scanCountryIdent = 157; }
        if (receivedNat == "Singapore") { scanCountryIdent = 158; }
        if (receivedNat == "Slovakia") { scanCountryIdent = 159; }
        if (receivedNat == "Slovenia") { scanCountryIdent = 160; }
        if (receivedNat == "Solomon Islands") { scanCountryIdent = 161; }
        if (receivedNat == "Somalia") { scanCountryIdent = 162; }
        if (receivedNat == "South Africa") { scanCountryIdent = 163; }
        if (receivedNat == "South Korea") { scanCountryIdent = 164; }
        if (receivedNat == "South Sudan") { scanCountryIdent = 165; }
        if (receivedNat == "Spain") { scanCountryIdent = 166; }
        if (receivedNat == "Sri Lanka") { scanCountryIdent = 167; }
        if (receivedNat == "St. Vincent & the Grenadines") { scanCountryIdent = 168; }
        if (receivedNat == "Sudan") { scanCountryIdent = 169; }
        if (receivedNat == "Suriname") { scanCountryIdent = 170; }
        if (receivedNat == "Sweden") { scanCountryIdent = 171; }
        if (receivedNat == "Switzerland") { scanCountryIdent = 172; }
        if (receivedNat == "Syria") { scanCountryIdent = 173; }
        if (receivedNat == "Taiwan") { scanCountryIdent = 174; }
        if (receivedNat == "Tajikistan") { scanCountryIdent = 175; }
        if (receivedNat == "Tanzania") { scanCountryIdent = 176; }
        if (receivedNat == "Thailand") { scanCountryIdent = 177; }
        if (receivedNat == "Timor-Leste") { scanCountryIdent = 178; }
        if (receivedNat == "Togo") { scanCountryIdent = 179; }
        if (receivedNat == "Tonga") { scanCountryIdent = 180; }
        if (receivedNat == "Trinidad and Tobago") { scanCountryIdent = 181; }
        if (receivedNat == "Tunisia") { scanCountryIdent = 182; }
        if (receivedNat == "Turkey") { scanCountryIdent = 183; }
        if (receivedNat == "Turkmenistan") { scanCountryIdent = 184; }
        if (receivedNat == "Tuvalu") { scanCountryIdent = 185; }
        if (receivedNat == "Uganda") { scanCountryIdent = 186; }
        if (receivedNat == "Ukraine") { scanCountryIdent = 187; }
        if (receivedNat == "United Arab Emirates") { scanCountryIdent = 188; }
        if (receivedNat == "United Kingdom") { scanCountryIdent = 189; }
        if (receivedNat == "United States of America") { scanCountryIdent = 190; }
        if (receivedNat == "Uruguay") { scanCountryIdent = 191; }
        if (receivedNat == "Uzbekistan") { scanCountryIdent = 192; }
        if (receivedNat == "Vanuatu") { scanCountryIdent = 193; }
        if (receivedNat == "Vatican City State") { scanCountryIdent = 194; }
        if (receivedNat == "Venezuela") { scanCountryIdent = 195; }
        if (receivedNat == "Vietnam") { scanCountryIdent = 196; }
        if (receivedNat == "Yemen") { scanCountryIdent = 197; }
        if (receivedNat == "Zambia") { scanCountryIdent = 198; }
        if (receivedNat == "Zimbabwe") { scanCountryIdent = 199; }
    }

    private void setCountryIdentifier()
    {
        if (detectedCountryName == "AFG") { countryIdentifier = 1; }
        if (detectedCountryName == "ALB") { countryIdentifier = 2; }
        if (detectedCountryName == "DZA") { countryIdentifier = 3; }
        if (detectedCountryName == "AND") { countryIdentifier = 4; }
        if (detectedCountryName == "AGO") { countryIdentifier = 5; }
        if (detectedCountryName == "ATG") { countryIdentifier = 6; }
        if (detectedCountryName == "ARG") { countryIdentifier = 7; }
        if (detectedCountryName == "ARM") { countryIdentifier = 8; }
        if (detectedCountryName == "AUS") { countryIdentifier = 9; }
        if (detectedCountryName == "AUT") { countryIdentifier = 10; }
        if (detectedCountryName == "AZE") { countryIdentifier = 11; }
        if (detectedCountryName == "BHS") { countryIdentifier = 12; }
        if (detectedCountryName == "BHR") { countryIdentifier = 13; }
        if (detectedCountryName == "BGD") { countryIdentifier = 14; }
        if (detectedCountryName == "BRB") { countryIdentifier = 15; }
        if (detectedCountryName == "BLR") { countryIdentifier = 16; }
        if (detectedCountryName == "BEL") { countryIdentifier = 17; }
        if (detectedCountryName == "BLZ") { countryIdentifier = 18; }
        if (detectedCountryName == "BEN") { countryIdentifier = 19; }
        if (detectedCountryName == "BTN") { countryIdentifier = 20; }
        if (detectedCountryName == "BOL") { countryIdentifier = 21; }
        if (detectedCountryName == "BIH") { countryIdentifier = 22; }
        if (detectedCountryName == "BWA") { countryIdentifier = 23; }
        if (detectedCountryName == "BRA") { countryIdentifier = 24; }
        if (detectedCountryName == "BRN") { countryIdentifier = 25; }
        if (detectedCountryName == "BGR") { countryIdentifier = 26; }
        if (detectedCountryName == "BFA") { countryIdentifier = 27; }
        if (detectedCountryName == "BDI") { countryIdentifier = 28; }
        if (detectedCountryName == "KHM") { countryIdentifier = 29; }
        if (detectedCountryName == "CMR") { countryIdentifier = 30; }
        if (detectedCountryName == "CAN") { countryIdentifier = 31; }
        if (detectedCountryName == "CPV") { countryIdentifier = 32; }
        if (detectedCountryName == "CAF") { countryIdentifier = 33; }
        if (detectedCountryName == "TCD") { countryIdentifier = 34; }
        if (detectedCountryName == "CHL") { countryIdentifier = 35; }
        if (detectedCountryName == "CHN") { countryIdentifier = 36; }
        if (detectedCountryName == "COL") { countryIdentifier = 37; }
        if (detectedCountryName == "COM") { countryIdentifier = 38; }
        if (detectedCountryName == "COG") { countryIdentifier = 39; }
        if (detectedCountryName == "COD") { countryIdentifier = 40; }
        if (detectedCountryName == "CRI") { countryIdentifier = 41; }
        if (detectedCountryName == "CIV") { countryIdentifier = 42; }
        if (detectedCountryName == "HRV") { countryIdentifier = 43; }
        if (detectedCountryName == "CUB") { countryIdentifier = 44; }
        if (detectedCountryName == "CYP") { countryIdentifier = 45; }
        if (detectedCountryName == "CZE") { countryIdentifier = 46; }
        if (detectedCountryName == "DNK") { countryIdentifier = 47; }
        if (detectedCountryName == "DJI") { countryIdentifier = 48; }
        if (detectedCountryName == "DMA") { countryIdentifier = 49; }
        if (detectedCountryName == "DOM") { countryIdentifier = 50; }
        if (detectedCountryName == "ECU") { countryIdentifier = 51; }
        if (detectedCountryName == "EGY") { countryIdentifier = 52; }
        if (detectedCountryName == "SLV") { countryIdentifier = 53; }
        if (detectedCountryName == "GNQ") { countryIdentifier = 54; }
        if (detectedCountryName == "ERI") { countryIdentifier = 55; }
        if (detectedCountryName == "EST") { countryIdentifier = 56; }
        if (detectedCountryName == "SWZ") { countryIdentifier = 57; }
        if (detectedCountryName == "ETH") { countryIdentifier = 58; }
        if (detectedCountryName == "FJI") { countryIdentifier = 59; }
        if (detectedCountryName == "FIN") { countryIdentifier = 60; }
        if (detectedCountryName == "FRA") { countryIdentifier = 61; }
        if (detectedCountryName == "GAB") { countryIdentifier = 62; }
        if (detectedCountryName == "GMB") { countryIdentifier = 63; }
        if (detectedCountryName == "GEO") { countryIdentifier = 64; }
        if (detectedCountryName == "DEU") { countryIdentifier = 65; }
        if (detectedCountryName == "GHA") { countryIdentifier = 66; }
        if (detectedCountryName == "GRC") { countryIdentifier = 67; }
        if (detectedCountryName == "GRD") { countryIdentifier = 68; }
        if (detectedCountryName == "GTM") { countryIdentifier = 69; }
        if (detectedCountryName == "GIN") { countryIdentifier = 70; }
        if (detectedCountryName == "GNB") { countryIdentifier = 71; }
        if (detectedCountryName == "GUY") { countryIdentifier = 72; }
        if (detectedCountryName == "HTI") { countryIdentifier = 73; }
        if (detectedCountryName == "HND") { countryIdentifier = 74; }
        if (detectedCountryName == "HKG") { countryIdentifier = 75; }
        if (detectedCountryName == "HUN") { countryIdentifier = 76; }
        if (detectedCountryName == "ISL") { countryIdentifier = 77; }
        if (detectedCountryName == "IND") { countryIdentifier = 78; }
        if (detectedCountryName == "IDN") { countryIdentifier = 79; }
        if (detectedCountryName == "IRN") { countryIdentifier = 80; }
        if (detectedCountryName == "IRQ") { countryIdentifier = 81; }
        if (detectedCountryName == "IRL") { countryIdentifier = 82; }
        if (detectedCountryName == "ISR") { countryIdentifier = 83; }
        if (detectedCountryName == "ITA") { countryIdentifier = 84; }
        if (detectedCountryName == "JAM") { countryIdentifier = 85; }
        if (detectedCountryName == "JPN") { countryIdentifier = 86; }
        if (detectedCountryName == "JOR") { countryIdentifier = 87; }
        if (detectedCountryName == "KAZ") { countryIdentifier = 88; }
        if (detectedCountryName == "KEN") { countryIdentifier = 89; }
        if (detectedCountryName == "KIR") { countryIdentifier = 90; }
        if (detectedCountryName == "KOS") { countryIdentifier = 91; }
        if (detectedCountryName == "KWT") { countryIdentifier = 92; }
        if (detectedCountryName == "KGZ") { countryIdentifier = 93; }
        if (detectedCountryName == "LAO") { countryIdentifier = 94; }
        if (detectedCountryName == "LVA") { countryIdentifier = 95; }
        if (detectedCountryName == "LBN") { countryIdentifier = 96; }
        if (detectedCountryName == "LSO") { countryIdentifier = 97; }
        if (detectedCountryName == "LBR") { countryIdentifier = 98; }
        if (detectedCountryName == "LBY") { countryIdentifier = 99; }
        if (detectedCountryName == "LIE") { countryIdentifier = 100; }
        if (detectedCountryName == "LTU") { countryIdentifier = 101; }
        if (detectedCountryName == "LUX") { countryIdentifier = 102; }
        if (detectedCountryName == "MAC") { countryIdentifier = 103; }
        if (detectedCountryName == "MDG") { countryIdentifier = 104; }
        if (detectedCountryName == "MWI") { countryIdentifier = 105; }
        if (detectedCountryName == "MYS") { countryIdentifier = 106; }
        if (detectedCountryName == "MDV") { countryIdentifier = 107; }
        if (detectedCountryName == "MLI") { countryIdentifier = 108; }
        if (detectedCountryName == "MLT") { countryIdentifier = 109; }
        if (detectedCountryName == "MHL") { countryIdentifier = 110; }
        if (detectedCountryName == "MRT") { countryIdentifier = 111; }
        if (detectedCountryName == "MUS") { countryIdentifier = 112; }
        if (detectedCountryName == "MEX") { countryIdentifier = 113; }
        if (detectedCountryName == "FSM") { countryIdentifier = 114; }
        if (detectedCountryName == "MDA") { countryIdentifier = 115; }
        if (detectedCountryName == "MCO") { countryIdentifier = 116; }
        if (detectedCountryName == "MNG") { countryIdentifier = 117; }
        if (detectedCountryName == "MNE") { countryIdentifier = 118; }
        if (detectedCountryName == "MAR") { countryIdentifier = 119; }
        if (detectedCountryName == "MOZ") { countryIdentifier = 120; }
        if (detectedCountryName == "MMR") { countryIdentifier = 121; }
        if (detectedCountryName == "NAM") { countryIdentifier = 122; }
        if (detectedCountryName == "NRU") { countryIdentifier = 123; }
        if (detectedCountryName == "NPL") { countryIdentifier = 124; }
        if (detectedCountryName == "NLD") { countryIdentifier = 125; }
        if (detectedCountryName == "NZL") { countryIdentifier = 126; }
        if (detectedCountryName == "NIC") { countryIdentifier = 127; }
        if (detectedCountryName == "NER") { countryIdentifier = 128; }
        if (detectedCountryName == "NGA") { countryIdentifier = 129; }
        if (detectedCountryName == "PRK") { countryIdentifier = 130; }
        if (detectedCountryName == "MKD") { countryIdentifier = 131; }
        if (detectedCountryName == "NOR") { countryIdentifier = 132; }
        if (detectedCountryName == "OMN") { countryIdentifier = 133; }
        if (detectedCountryName == "PAK") { countryIdentifier = 134; }
        if (detectedCountryName == "PLW") { countryIdentifier = 135; }
        if (detectedCountryName == "PSE") { countryIdentifier = 136; }
        if (detectedCountryName == "PAN") { countryIdentifier = 137; }
        if (detectedCountryName == "PNG") { countryIdentifier = 138; }
        if (detectedCountryName == "PRY") { countryIdentifier = 139; }
        if (detectedCountryName == "PER") { countryIdentifier = 140; }
        if (detectedCountryName == "PHL") { countryIdentifier = 141; }
        if (detectedCountryName == "POL") { countryIdentifier = 142; }
        if (detectedCountryName == "PRT") { countryIdentifier = 143; }
        if (detectedCountryName == "QAT") { countryIdentifier = 144; }
        if (detectedCountryName == "ROU") { countryIdentifier = 145; }
        if (detectedCountryName == "RUS") { countryIdentifier = 146; }
        if (detectedCountryName == "RWA") { countryIdentifier = 147; }
        if (detectedCountryName == "KNA") { countryIdentifier = 148; }
        if (detectedCountryName == "LCA") { countryIdentifier = 149; }
        if (detectedCountryName == "WSM") { countryIdentifier = 150; }
        if (detectedCountryName == "SMR") { countryIdentifier = 151; }
        if (detectedCountryName == "STP") { countryIdentifier = 152; }
        if (detectedCountryName == "SAU") { countryIdentifier = 153; }
        if (detectedCountryName == "SEN") { countryIdentifier = 154; }
        if (detectedCountryName == "SRB") { countryIdentifier = 155; }
        if (detectedCountryName == "SYC") { countryIdentifier = 156; }
        if (detectedCountryName == "SLE") { countryIdentifier = 157; }
        if (detectedCountryName == "SGP") { countryIdentifier = 158; }
        if (detectedCountryName == "SVK") { countryIdentifier = 159; }
        if (detectedCountryName == "SVN") { countryIdentifier = 160; }
        if (detectedCountryName == "SLB") { countryIdentifier = 161; }
        if (detectedCountryName == "SOM") { countryIdentifier = 162; }
        if (detectedCountryName == "ZAF") { countryIdentifier = 163; }
        if (detectedCountryName == "KOR") { countryIdentifier = 164; }
        if (detectedCountryName == "SSD") { countryIdentifier = 165; }
        if (detectedCountryName == "ESP") { countryIdentifier = 166; }
        if (detectedCountryName == "LKA") { countryIdentifier = 167; }
        if (detectedCountryName == "VCT") { countryIdentifier = 168; }
        if (detectedCountryName == "SDN") { countryIdentifier = 169; }
        if (detectedCountryName == "SUR") { countryIdentifier = 170; }
        if (detectedCountryName == "SWE") { countryIdentifier = 171; }
        if (detectedCountryName == "CHE") { countryIdentifier = 172; }
        if (detectedCountryName == "SYR") { countryIdentifier = 173; }
        if (detectedCountryName == "TWN") { countryIdentifier = 174; }
        if (detectedCountryName == "TJK") { countryIdentifier = 175; }
        if (detectedCountryName == "TZA") { countryIdentifier = 176; }
        if (detectedCountryName == "THA") { countryIdentifier = 177; }
        if (detectedCountryName == "TLS") { countryIdentifier = 178; }
        if (detectedCountryName == "TGO") { countryIdentifier = 179; }
        if (detectedCountryName == "TON") { countryIdentifier = 180; }
        if (detectedCountryName == "TTO") { countryIdentifier = 181; }
        if (detectedCountryName == "TUN") { countryIdentifier = 182; }
        if (detectedCountryName == "TUR") { countryIdentifier = 183; }
        if (detectedCountryName == "TKM") { countryIdentifier = 184; }
        if (detectedCountryName == "TUV") { countryIdentifier = 185; }
        if (detectedCountryName == "UGA") { countryIdentifier = 186; }
        if (detectedCountryName == "UKR") { countryIdentifier = 187; }
        if (detectedCountryName == "ARE") { countryIdentifier = 188; }
        if (detectedCountryName == "GBR") { countryIdentifier = 189; }
        if (detectedCountryName == "USA") { countryIdentifier = 190; }
        if (detectedCountryName == "URY") { countryIdentifier = 191; }
        if (detectedCountryName == "UZB") { countryIdentifier = 192; }
        if (detectedCountryName == "VUT") { countryIdentifier = 193; }
        if (detectedCountryName == "VAT") { countryIdentifier = 194; }
        if (detectedCountryName == "VEN") { countryIdentifier = 195; }
        if (detectedCountryName == "VNM") { countryIdentifier = 196; }
        if (detectedCountryName == "YEM") { countryIdentifier = 197; }
        if (detectedCountryName == "ZMB") { countryIdentifier = 198; }
        if (detectedCountryName == "ZWE") { countryIdentifier = 199; }
    }
}
