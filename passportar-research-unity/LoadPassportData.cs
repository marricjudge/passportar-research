using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPassportData : MonoBehaviour
{
    public List<passportdataclass> passportdatalist = new List<passportdataclass>();
    // CSV data parsing concept from https://www.youtube.com/watch?v=mAeTRCT0qZg (last access 22.05.2020)
    void Start()
    {
        TextAsset passportdata = Resources.Load<TextAsset>("passportdata");
        string[] data = passportdata.text.Split(new char[] { '\n' });

        for (int i = 0; i < data.Length - 1; i++)
        { 
            string[] cell = data[i].Split(new char[] { ',' });
            passportdataclass ppd = new passportdataclass();
            ppd.countryID = cell[0];
            int.TryParse(cell[1], out ppd.passportpower);
            int.TryParse(cell[2], out ppd.AD);
            int.TryParse(cell[3], out ppd.AE);
            int.TryParse(cell[4], out ppd.AF);
            int.TryParse(cell[5], out ppd.AG);
            int.TryParse(cell[6], out ppd.AL);
            int.TryParse(cell[7], out ppd.AM);
            int.TryParse(cell[8], out ppd.AO);
            int.TryParse(cell[9], out ppd.AR);
            int.TryParse(cell[10], out ppd.AT);
            int.TryParse(cell[11], out ppd.AU);
            int.TryParse(cell[12], out ppd.AZ);
            int.TryParse(cell[13], out ppd.BA);
            int.TryParse(cell[14], out ppd.BB);
            int.TryParse(cell[15], out ppd.BD);
            int.TryParse(cell[16], out ppd.BE);
            int.TryParse(cell[17], out ppd.BF);
            int.TryParse(cell[18], out ppd.BG);
            int.TryParse(cell[19], out ppd.BH);
            int.TryParse(cell[20], out ppd.BI);
            int.TryParse(cell[21], out ppd.BJ);
            int.TryParse(cell[22], out ppd.BN);
            int.TryParse(cell[23], out ppd.BO);
            int.TryParse(cell[24], out ppd.BR);
            int.TryParse(cell[25], out ppd.BS);
            int.TryParse(cell[26], out ppd.BT);
            int.TryParse(cell[27], out ppd.BW);
            int.TryParse(cell[28], out ppd.BY);
            int.TryParse(cell[29], out ppd.BZ);
            int.TryParse(cell[30], out ppd.CA);
            int.TryParse(cell[31], out ppd.CD);
            int.TryParse(cell[32], out ppd.CF);
            int.TryParse(cell[33], out ppd.CG);
            int.TryParse(cell[34], out ppd.CH);
            int.TryParse(cell[35], out ppd.CI);
            int.TryParse(cell[36], out ppd.CL);
            int.TryParse(cell[37], out ppd.CM);
            int.TryParse(cell[38], out ppd.CN);
            int.TryParse(cell[39], out ppd.CO);
            int.TryParse(cell[40], out ppd.CR);
            int.TryParse(cell[41], out ppd.CU);
            int.TryParse(cell[42], out ppd.CV);
            int.TryParse(cell[43], out ppd.CY);
            int.TryParse(cell[44], out ppd.CZ);
            int.TryParse(cell[45], out ppd.DE);
            int.TryParse(cell[46], out ppd.DJ);
            int.TryParse(cell[47], out ppd.DK);
            int.TryParse(cell[48], out ppd.DM);
            int.TryParse(cell[49], out ppd.DO);
            int.TryParse(cell[50], out ppd.DZ);
            int.TryParse(cell[51], out ppd.EC);
            int.TryParse(cell[52], out ppd.EE);
            int.TryParse(cell[53], out ppd.EG);
            int.TryParse(cell[54], out ppd.ER);
            int.TryParse(cell[55], out ppd.ES);
            int.TryParse(cell[56], out ppd.ET);
            int.TryParse(cell[57], out ppd.FI);
            int.TryParse(cell[58], out ppd.FJ);
            int.TryParse(cell[59], out ppd.FM);
            int.TryParse(cell[60], out ppd.FR);
            int.TryParse(cell[61], out ppd.GA);
            int.TryParse(cell[62], out ppd.GB);
            int.TryParse(cell[63], out ppd.GD);
            int.TryParse(cell[64], out ppd.GE);
            int.TryParse(cell[65], out ppd.GH);
            int.TryParse(cell[66], out ppd.GM);
            int.TryParse(cell[67], out ppd.GN);
            int.TryParse(cell[68], out ppd.GQ);
            int.TryParse(cell[69], out ppd.GR);
            int.TryParse(cell[70], out ppd.GT);
            int.TryParse(cell[71], out ppd.GW);
            int.TryParse(cell[72], out ppd.GY);
            int.TryParse(cell[73], out ppd.HK);
            int.TryParse(cell[74], out ppd.HN);
            int.TryParse(cell[75], out ppd.HR);
            int.TryParse(cell[76], out ppd.HT);
            int.TryParse(cell[77], out ppd.HU);
            int.TryParse(cell[78], out ppd.ID);
            int.TryParse(cell[79], out ppd.IE);
            int.TryParse(cell[80], out ppd.IL);
            int.TryParse(cell[81], out ppd.IN);
            int.TryParse(cell[82], out ppd.IQ);
            int.TryParse(cell[83], out ppd.IR);
            int.TryParse(cell[84], out ppd.IS);
            int.TryParse(cell[85], out ppd.IT);
            int.TryParse(cell[86], out ppd.JM);
            int.TryParse(cell[87], out ppd.JO);
            int.TryParse(cell[88], out ppd.JP);
            int.TryParse(cell[89], out ppd.KE);
            int.TryParse(cell[90], out ppd.KG);
            int.TryParse(cell[91], out ppd.KH);
            int.TryParse(cell[92], out ppd.KI);
            int.TryParse(cell[93], out ppd.KM);
            int.TryParse(cell[94], out ppd.KN);
            int.TryParse(cell[95], out ppd.KP);
            int.TryParse(cell[96], out ppd.KR);
            int.TryParse(cell[97], out ppd.KW);
            int.TryParse(cell[98], out ppd.KZ);
            int.TryParse(cell[99], out ppd.LA);
            int.TryParse(cell[100], out ppd.LB);
            int.TryParse(cell[101], out ppd.LC);
            int.TryParse(cell[102], out ppd.LI);
            int.TryParse(cell[103], out ppd.LK);
            int.TryParse(cell[104], out ppd.LR);
            int.TryParse(cell[105], out ppd.LS);
            int.TryParse(cell[106], out ppd.LT);
            int.TryParse(cell[107], out ppd.LU);
            int.TryParse(cell[108], out ppd.LV);
            int.TryParse(cell[109], out ppd.LY);
            int.TryParse(cell[110], out ppd.MA);
            int.TryParse(cell[111], out ppd.MC);
            int.TryParse(cell[112], out ppd.MD);
            int.TryParse(cell[113], out ppd.ME);
            int.TryParse(cell[114], out ppd.MG);
            int.TryParse(cell[115], out ppd.MH);
            int.TryParse(cell[116], out ppd.MK);
            int.TryParse(cell[117], out ppd.ML);
            int.TryParse(cell[118], out ppd.MM);
            int.TryParse(cell[119], out ppd.MN);
            int.TryParse(cell[120], out ppd.MO);
            int.TryParse(cell[121], out ppd.MR);
            int.TryParse(cell[122], out ppd.MT);
            int.TryParse(cell[123], out ppd.MU);
            int.TryParse(cell[124], out ppd.MV);
            int.TryParse(cell[125], out ppd.MW);
            int.TryParse(cell[126], out ppd.MX);
            int.TryParse(cell[127], out ppd.MY);
            int.TryParse(cell[128], out ppd.MZ);
            int.TryParse(cell[129], out ppd.NA);
            int.TryParse(cell[130], out ppd.NE);
            int.TryParse(cell[131], out ppd.NG);
            int.TryParse(cell[132], out ppd.NI);
            int.TryParse(cell[133], out ppd.NL);
            int.TryParse(cell[134], out ppd.NO);
            int.TryParse(cell[135], out ppd.NP);
            int.TryParse(cell[136], out ppd.NR);
            int.TryParse(cell[137], out ppd.NZ);
            int.TryParse(cell[138], out ppd.OM);
            int.TryParse(cell[139], out ppd.PA);
            int.TryParse(cell[140], out ppd.PE);
            int.TryParse(cell[141], out ppd.PG);
            int.TryParse(cell[142], out ppd.PH);
            int.TryParse(cell[143], out ppd.PK);
            int.TryParse(cell[144], out ppd.PL);
            int.TryParse(cell[145], out ppd.PS);
            int.TryParse(cell[146], out ppd.PT);
            int.TryParse(cell[147], out ppd.PW);
            int.TryParse(cell[148], out ppd.PY);
            int.TryParse(cell[149], out ppd.QA);
            int.TryParse(cell[150], out ppd.RK);
            int.TryParse(cell[151], out ppd.RO);
            int.TryParse(cell[152], out ppd.RS);
            int.TryParse(cell[153], out ppd.RU);
            int.TryParse(cell[154], out ppd.RW);
            int.TryParse(cell[155], out ppd.SA);
            int.TryParse(cell[156], out ppd.SB);
            int.TryParse(cell[157], out ppd.SC);
            int.TryParse(cell[158], out ppd.SD);
            int.TryParse(cell[159], out ppd.SE);
            int.TryParse(cell[160], out ppd.SG);
            int.TryParse(cell[161], out ppd.SI);
            int.TryParse(cell[162], out ppd.SK);
            int.TryParse(cell[163], out ppd.SL);
            int.TryParse(cell[164], out ppd.SM);
            int.TryParse(cell[165], out ppd.SN);
            int.TryParse(cell[166], out ppd.SO);
            int.TryParse(cell[167], out ppd.SR);
            int.TryParse(cell[168], out ppd.SS);
            int.TryParse(cell[169], out ppd.ST);
            int.TryParse(cell[170], out ppd.SV);
            int.TryParse(cell[171], out ppd.SY);
            int.TryParse(cell[172], out ppd.SZ);
            int.TryParse(cell[173], out ppd.TD);
            int.TryParse(cell[174], out ppd.TG);
            int.TryParse(cell[175], out ppd.TH);
            int.TryParse(cell[176], out ppd.TJ);
            int.TryParse(cell[177], out ppd.TL);
            int.TryParse(cell[178], out ppd.TM);
            int.TryParse(cell[179], out ppd.TN);
            int.TryParse(cell[180], out ppd.TO);
            int.TryParse(cell[181], out ppd.TR);
            int.TryParse(cell[182], out ppd.TT);
            int.TryParse(cell[183], out ppd.TV);
            int.TryParse(cell[184], out ppd.TW);
            int.TryParse(cell[185], out ppd.TZ);
            int.TryParse(cell[186], out ppd.UA);
            int.TryParse(cell[187], out ppd.UG);
            int.TryParse(cell[188], out ppd.US);
            int.TryParse(cell[189], out ppd.UY);
            int.TryParse(cell[190], out ppd.UZ);
            int.TryParse(cell[191], out ppd.VA);
            int.TryParse(cell[192], out ppd.VC);
            int.TryParse(cell[193], out ppd.VE);
            int.TryParse(cell[194], out ppd.VN);
            int.TryParse(cell[195], out ppd.VU);
            int.TryParse(cell[196], out ppd.WS);
            int.TryParse(cell[197], out ppd.YE);
            int.TryParse(cell[198], out ppd.ZA);
            int.TryParse(cell[199], out ppd.ZM);
            int.TryParse(cell[200], out ppd.ZW);
            int.TryParse(cell[201], out ppd.rank);
            passportdatalist.Add(ppd);
        }
    }

    public List<string> sendCountryList()
    {
        List<string> returnCountryList = new List<string>();
        foreach (passportdataclass ppd in passportdatalist)
        {
            returnCountryList.Add(ppd.countryID);
        }
        return returnCountryList;
    }

    public List<int> sendPassportPowerList()
    {
        List<int> returnPassportPowerList = new List<int>();
        foreach (passportdataclass ppd in passportdatalist)
        {
            returnPassportPowerList.Add(ppd.passportpower);
        }
        return returnPassportPowerList;
    }

    public List<int> sendPassportRankList()
    {
        List<int> returnPassportRankList = new List<int>();
        foreach (passportdataclass ppd in passportdatalist)
        {
            returnPassportRankList.Add(ppd.rank);
        }
        return returnPassportRankList;
    }


    public List<int> sendData(int detectedNationality)
    { //Support from https://forum.unity.com/threads/return-an-array-list-of-values.196633/ (last access 22.05.2020)
        List<int> toBeReturned = new List<int>();
        
        foreach (passportdataclass ppd in passportdatalist)
        {
            if (detectedNationality == 0) { toBeReturned.Add(ppd.DE); }
            else if (detectedNationality == 1) { toBeReturned.Add(ppd.AD); }
            else if (detectedNationality == 2) { toBeReturned.Add(ppd.AE); }
            else if (detectedNationality == 3) { toBeReturned.Add(ppd.AF); }
            else if (detectedNationality == 4) { toBeReturned.Add(ppd.AG); }
            else if (detectedNationality == 5) { toBeReturned.Add(ppd.AL); }
            else if (detectedNationality == 6) { toBeReturned.Add(ppd.AM); }
            else if (detectedNationality == 7) { toBeReturned.Add(ppd.AO); }
            else if (detectedNationality == 8) { toBeReturned.Add(ppd.AR); }
            else if (detectedNationality == 9) { toBeReturned.Add(ppd.AT); }
            else if (detectedNationality == 10) { toBeReturned.Add(ppd.AU); }
            else if (detectedNationality == 11) { toBeReturned.Add(ppd.AZ); }
            else if (detectedNationality == 12) { toBeReturned.Add(ppd.BA); }
            else if (detectedNationality == 13) { toBeReturned.Add(ppd.BB); }
            else if (detectedNationality == 14) { toBeReturned.Add(ppd.BD); }
            else if (detectedNationality == 15) { toBeReturned.Add(ppd.BE); }
            else if (detectedNationality == 16) { toBeReturned.Add(ppd.BF); }
            else if (detectedNationality == 17) { toBeReturned.Add(ppd.BG); }
            else if (detectedNationality == 18) { toBeReturned.Add(ppd.BH); }
            else if (detectedNationality == 19) { toBeReturned.Add(ppd.BI); }
            else if (detectedNationality == 20) { toBeReturned.Add(ppd.BJ); }
            else if (detectedNationality == 21) { toBeReturned.Add(ppd.BN); }
            else if (detectedNationality == 22) { toBeReturned.Add(ppd.BO); }
            else if (detectedNationality == 23) { toBeReturned.Add(ppd.BR); }
            else if (detectedNationality == 24) { toBeReturned.Add(ppd.BS); }
            else if (detectedNationality == 25) { toBeReturned.Add(ppd.BT); }
            else if (detectedNationality == 26) { toBeReturned.Add(ppd.BW); }
            else if (detectedNationality == 27) { toBeReturned.Add(ppd.BY); }
            else if (detectedNationality == 28) { toBeReturned.Add(ppd.BZ); }
            else if (detectedNationality == 29) { toBeReturned.Add(ppd.CA); }
            else if (detectedNationality == 30) { toBeReturned.Add(ppd.CD); }
            else if (detectedNationality == 31) { toBeReturned.Add(ppd.CF); }
            else if (detectedNationality == 32) { toBeReturned.Add(ppd.CG); }
            else if (detectedNationality == 33) { toBeReturned.Add(ppd.CH); }
            else if (detectedNationality == 34) { toBeReturned.Add(ppd.CI); }
            else if (detectedNationality == 35) { toBeReturned.Add(ppd.CL); }
            else if (detectedNationality == 36) { toBeReturned.Add(ppd.CM); }
            else if (detectedNationality == 37) { toBeReturned.Add(ppd.CN); }
            else if (detectedNationality == 38) { toBeReturned.Add(ppd.CO); }
            else if (detectedNationality == 39) { toBeReturned.Add(ppd.CR); }
            else if (detectedNationality == 40) { toBeReturned.Add(ppd.CU); }
            else if (detectedNationality == 41) { toBeReturned.Add(ppd.CV); }
            else if (detectedNationality == 42) { toBeReturned.Add(ppd.CY); }
            else if (detectedNationality == 43) { toBeReturned.Add(ppd.CZ); }
            else if (detectedNationality == 44) { toBeReturned.Add(ppd.DE); }
            else if (detectedNationality == 45) { toBeReturned.Add(ppd.DJ); }
            else if (detectedNationality == 46) { toBeReturned.Add(ppd.DK); }
            else if (detectedNationality == 47) { toBeReturned.Add(ppd.DM); }
            else if (detectedNationality == 48) { toBeReturned.Add(ppd.DO); }
            else if (detectedNationality == 49) { toBeReturned.Add(ppd.DZ); }
            else if (detectedNationality == 50) { toBeReturned.Add(ppd.EC); }
            else if (detectedNationality == 51) { toBeReturned.Add(ppd.EE); }
            else if (detectedNationality == 52) { toBeReturned.Add(ppd.EG); }
            else if (detectedNationality == 53) { toBeReturned.Add(ppd.ER); }
            else if (detectedNationality == 54) { toBeReturned.Add(ppd.ES); }
            else if (detectedNationality == 55) { toBeReturned.Add(ppd.ET); }
            else if (detectedNationality == 56) { toBeReturned.Add(ppd.FI); }
            else if (detectedNationality == 57) { toBeReturned.Add(ppd.FJ); }
            else if (detectedNationality == 58) { toBeReturned.Add(ppd.FM); }
            else if (detectedNationality == 59) { toBeReturned.Add(ppd.FR); }
            else if (detectedNationality == 60) { toBeReturned.Add(ppd.GA); }
            else if (detectedNationality == 61 || detectedNationality == 200) { toBeReturned.Add(ppd.GB); }
            else if (detectedNationality == 62) { toBeReturned.Add(ppd.GD); }
            else if (detectedNationality == 63) { toBeReturned.Add(ppd.GE); }
            else if (detectedNationality == 64) { toBeReturned.Add(ppd.GH); }
            else if (detectedNationality == 65) { toBeReturned.Add(ppd.GM); }
            else if (detectedNationality == 66) { toBeReturned.Add(ppd.GN); }
            else if (detectedNationality == 67) { toBeReturned.Add(ppd.GQ); }
            else if (detectedNationality == 68) { toBeReturned.Add(ppd.GR); }
            else if (detectedNationality == 69) { toBeReturned.Add(ppd.GT); }
            else if (detectedNationality == 70) { toBeReturned.Add(ppd.GW); }
            else if (detectedNationality == 71) { toBeReturned.Add(ppd.GY); }
            else if (detectedNationality == 72) { toBeReturned.Add(ppd.HK); }
            else if (detectedNationality == 73) { toBeReturned.Add(ppd.HN); }
            else if (detectedNationality == 74) { toBeReturned.Add(ppd.HR); }
            else if (detectedNationality == 75) { toBeReturned.Add(ppd.HT); }
            else if (detectedNationality == 76) { toBeReturned.Add(ppd.HU); }
            else if (detectedNationality == 77) { toBeReturned.Add(ppd.ID); }
            else if (detectedNationality == 78) { toBeReturned.Add(ppd.IE); }
            else if (detectedNationality == 79) { toBeReturned.Add(ppd.IL); }
            else if (detectedNationality == 80) { toBeReturned.Add(ppd.IN); }
            else if (detectedNationality == 81) { toBeReturned.Add(ppd.IQ); }
            else if (detectedNationality == 82) { toBeReturned.Add(ppd.IR); }
            else if (detectedNationality == 83) { toBeReturned.Add(ppd.IS); }
            else if (detectedNationality == 84) { toBeReturned.Add(ppd.IT); }
            else if (detectedNationality == 85) { toBeReturned.Add(ppd.JM); }
            else if (detectedNationality == 86) { toBeReturned.Add(ppd.JO); }
            else if (detectedNationality == 87) { toBeReturned.Add(ppd.JP); }
            else if (detectedNationality == 88) { toBeReturned.Add(ppd.KE); }
            else if (detectedNationality == 89) { toBeReturned.Add(ppd.KG); }
            else if (detectedNationality == 90) { toBeReturned.Add(ppd.KH); }
            else if (detectedNationality == 91) { toBeReturned.Add(ppd.KI); }
            else if (detectedNationality == 92) { toBeReturned.Add(ppd.KM); }
            else if (detectedNationality == 93) { toBeReturned.Add(ppd.KN); }
            else if (detectedNationality == 94) { toBeReturned.Add(ppd.KP); }
            else if (detectedNationality == 95) { toBeReturned.Add(ppd.KR); }
            else if (detectedNationality == 96) { toBeReturned.Add(ppd.KW); }
            else if (detectedNationality == 97) { toBeReturned.Add(ppd.KZ); }
            else if (detectedNationality == 98) { toBeReturned.Add(ppd.LA); }
            else if (detectedNationality == 99) { toBeReturned.Add(ppd.LB); }
            else if (detectedNationality == 100) { toBeReturned.Add(ppd.LC); }
            else if (detectedNationality == 101) { toBeReturned.Add(ppd.LI); }
            else if (detectedNationality == 102) { toBeReturned.Add(ppd.LK); }
            else if (detectedNationality == 103) { toBeReturned.Add(ppd.LR); }
            else if (detectedNationality == 104) { toBeReturned.Add(ppd.LS); }
            else if (detectedNationality == 105) { toBeReturned.Add(ppd.LT); }
            else if (detectedNationality == 106) { toBeReturned.Add(ppd.LU); }
            else if (detectedNationality == 107) { toBeReturned.Add(ppd.LV); }
            else if (detectedNationality == 108) { toBeReturned.Add(ppd.LY); }
            else if (detectedNationality == 109) { toBeReturned.Add(ppd.MA); }
            else if (detectedNationality == 110) { toBeReturned.Add(ppd.MC); }
            else if (detectedNationality == 111) { toBeReturned.Add(ppd.MD); }
            else if (detectedNationality == 112) { toBeReturned.Add(ppd.ME); }
            else if (detectedNationality == 113) { toBeReturned.Add(ppd.MG); }
            else if (detectedNationality == 114) { toBeReturned.Add(ppd.MH); }
            else if (detectedNationality == 115) { toBeReturned.Add(ppd.MK); }
            else if (detectedNationality == 116) { toBeReturned.Add(ppd.ML); }
            else if (detectedNationality == 117) { toBeReturned.Add(ppd.MM); }
            else if (detectedNationality == 118) { toBeReturned.Add(ppd.MN); }
            else if (detectedNationality == 119) { toBeReturned.Add(ppd.MO); }
            else if (detectedNationality == 120) { toBeReturned.Add(ppd.MR); }
            else if (detectedNationality == 121) { toBeReturned.Add(ppd.MT); }
            else if (detectedNationality == 122) { toBeReturned.Add(ppd.MU); }
            else if (detectedNationality == 123) { toBeReturned.Add(ppd.MV); }
            else if (detectedNationality == 124) { toBeReturned.Add(ppd.MW); }
            else if (detectedNationality == 125) { toBeReturned.Add(ppd.MX); }
            else if (detectedNationality == 126) { toBeReturned.Add(ppd.MY); }
            else if (detectedNationality == 127) { toBeReturned.Add(ppd.MZ); }
            else if (detectedNationality == 128) { toBeReturned.Add(ppd.NA); }
            else if (detectedNationality == 129) { toBeReturned.Add(ppd.NE); }
            else if (detectedNationality == 130) { toBeReturned.Add(ppd.NG); }
            else if (detectedNationality == 131) { toBeReturned.Add(ppd.NI); }
            else if (detectedNationality == 132) { toBeReturned.Add(ppd.NL); }
            else if (detectedNationality == 133) { toBeReturned.Add(ppd.NO); }
            else if (detectedNationality == 134) { toBeReturned.Add(ppd.NP); }
            else if (detectedNationality == 135) { toBeReturned.Add(ppd.NR); }
            else if (detectedNationality == 136) { toBeReturned.Add(ppd.NZ); }
            else if (detectedNationality == 137) { toBeReturned.Add(ppd.OM); }
            else if (detectedNationality == 138) { toBeReturned.Add(ppd.PA); }
            else if (detectedNationality == 139) { toBeReturned.Add(ppd.PE); }
            else if (detectedNationality == 140) { toBeReturned.Add(ppd.PG); }
            else if (detectedNationality == 141) { toBeReturned.Add(ppd.PH); }
            else if (detectedNationality == 142) { toBeReturned.Add(ppd.PK); }
            else if (detectedNationality == 143) { toBeReturned.Add(ppd.PL); }
            else if (detectedNationality == 144) { toBeReturned.Add(ppd.PS); }
            else if (detectedNationality == 145) { toBeReturned.Add(ppd.PT); }
            else if (detectedNationality == 146) { toBeReturned.Add(ppd.PW); }
            else if (detectedNationality == 147) { toBeReturned.Add(ppd.PY); }
            else if (detectedNationality == 148) { toBeReturned.Add(ppd.QA); }
            else if (detectedNationality == 149) { toBeReturned.Add(ppd.RK); }
            else if (detectedNationality == 150) { toBeReturned.Add(ppd.RO); }
            else if (detectedNationality == 151) { toBeReturned.Add(ppd.RS); }
            else if (detectedNationality == 152) { toBeReturned.Add(ppd.RU); }
            else if (detectedNationality == 153) { toBeReturned.Add(ppd.RW); }
            else if (detectedNationality == 154) { toBeReturned.Add(ppd.SA); }
            else if (detectedNationality == 155) { toBeReturned.Add(ppd.SB); }
            else if (detectedNationality == 156) { toBeReturned.Add(ppd.SC); }
            else if (detectedNationality == 157) { toBeReturned.Add(ppd.SD); }
            else if (detectedNationality == 158) { toBeReturned.Add(ppd.SE); }
            else if (detectedNationality == 159) { toBeReturned.Add(ppd.SG); }
            else if (detectedNationality == 160) { toBeReturned.Add(ppd.SI); }
            else if (detectedNationality == 161) { toBeReturned.Add(ppd.SK); }
            else if (detectedNationality == 162) { toBeReturned.Add(ppd.SL); }
            else if (detectedNationality == 163) { toBeReturned.Add(ppd.SM); }
            else if (detectedNationality == 164) { toBeReturned.Add(ppd.SN); }
            else if (detectedNationality == 165) { toBeReturned.Add(ppd.SO); }
            else if (detectedNationality == 166) { toBeReturned.Add(ppd.SR); }
            else if (detectedNationality == 167) { toBeReturned.Add(ppd.SS); }
            else if (detectedNationality == 168) { toBeReturned.Add(ppd.ST); }
            else if (detectedNationality == 169) { toBeReturned.Add(ppd.SV); }
            else if (detectedNationality == 170) { toBeReturned.Add(ppd.SY); }
            else if (detectedNationality == 171) { toBeReturned.Add(ppd.SZ); }
            else if (detectedNationality == 172) { toBeReturned.Add(ppd.TD); }
            else if (detectedNationality == 173) { toBeReturned.Add(ppd.TG); }
            else if (detectedNationality == 174) { toBeReturned.Add(ppd.TH); }
            else if (detectedNationality == 175) { toBeReturned.Add(ppd.TJ); }
            else if (detectedNationality == 176) { toBeReturned.Add(ppd.TL); }
            else if (detectedNationality == 177) { toBeReturned.Add(ppd.TM); }
            else if (detectedNationality == 178) { toBeReturned.Add(ppd.TN); }
            else if (detectedNationality == 179) { toBeReturned.Add(ppd.TO); }
            else if (detectedNationality == 180) { toBeReturned.Add(ppd.TR); }
            else if (detectedNationality == 181) { toBeReturned.Add(ppd.TT); }
            else if (detectedNationality == 182) { toBeReturned.Add(ppd.TV); }
            else if (detectedNationality == 183) { toBeReturned.Add(ppd.TW); }
            else if (detectedNationality == 184) { toBeReturned.Add(ppd.TZ); }
            else if (detectedNationality == 185) { toBeReturned.Add(ppd.UA); }
            else if (detectedNationality == 186) { toBeReturned.Add(ppd.UG); }
            else if (detectedNationality == 187) { toBeReturned.Add(ppd.US); }
            else if (detectedNationality == 188) { toBeReturned.Add(ppd.UY); }
            else if (detectedNationality == 189) { toBeReturned.Add(ppd.UZ); }
            else if (detectedNationality == 190) { toBeReturned.Add(ppd.VA); }
            else if (detectedNationality == 191) { toBeReturned.Add(ppd.VC); }
            else if (detectedNationality == 192) { toBeReturned.Add(ppd.VE); }
            else if (detectedNationality == 193) { toBeReturned.Add(ppd.VN); }
            else if (detectedNationality == 194) { toBeReturned.Add(ppd.VU); }
            else if (detectedNationality == 195) { toBeReturned.Add(ppd.WS); }
            else if (detectedNationality == 196) { toBeReturned.Add(ppd.YE); }
            else if (detectedNationality == 197) { toBeReturned.Add(ppd.ZA); }
            else if (detectedNationality == 198) { toBeReturned.Add(ppd.ZM); }
            else if (detectedNationality == 199) { toBeReturned.Add(ppd.ZW); }
            else { }
        }
        return toBeReturned;
    }
}
