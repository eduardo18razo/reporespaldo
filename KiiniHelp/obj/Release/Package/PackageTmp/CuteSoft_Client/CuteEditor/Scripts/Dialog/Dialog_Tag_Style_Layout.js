var OxO8f06=["","sel_position","sel_display","sel_float","sel_clear","tb_top","sel_top_unit","tb_height","sel_height_unit","tb_left","sel_left_unit","tb_width","sel_width_unit","tb_cliptop","sel_cliptop_unit","tb_clipbottom","sel_clipbottom_unit","tb_clipleft","sel_clipleft_unit","tb_clipright","sel_clipright_unit","sel_overflow","tb_zindex","sel_pagebreakbefore","sel_pagebreakafter","outer","div_demo","cssText","style","value","position","display","styleFloat","cssFloat","clear","left","top","width","height","length","tb_","sel_","_unit","selectedIndex","options","right","bottom","clip","tb_clip","sel_clip","currentStyle","overflow","zIndex","pageBreakBefore","pageBreakAfter"];function ParseFloatToString(Ox24){var Ox8=parseFloat(Ox24);if(isNaN(Ox8)){return OxO8f06[0];} ;return Ox8+OxO8f06[0];} ;var sel_position=Window_GetElement(window,OxO8f06[1],true);var sel_display=Window_GetElement(window,OxO8f06[2],true);var sel_float=Window_GetElement(window,OxO8f06[3],true);var sel_clear=Window_GetElement(window,OxO8f06[4],true);var tb_top=Window_GetElement(window,OxO8f06[5],true);var sel_top_unit=Window_GetElement(window,OxO8f06[6],true);var tb_height=Window_GetElement(window,OxO8f06[7],true);var sel_height_unit=Window_GetElement(window,OxO8f06[8],true);var tb_left=Window_GetElement(window,OxO8f06[9],true);var sel_left_unit=Window_GetElement(window,OxO8f06[10],true);var tb_width=Window_GetElement(window,OxO8f06[11],true);var sel_width_unit=Window_GetElement(window,OxO8f06[12],true);var tb_cliptop=Window_GetElement(window,OxO8f06[13],true);var sel_cliptop_unit=Window_GetElement(window,OxO8f06[14],true);var tb_clipbottom=Window_GetElement(window,OxO8f06[15],true);var sel_clipbottom_unit=Window_GetElement(window,OxO8f06[16],true);var tb_clipleft=Window_GetElement(window,OxO8f06[17],true);var sel_clipleft_unit=Window_GetElement(window,OxO8f06[18],true);var tb_clipright=Window_GetElement(window,OxO8f06[19],true);var sel_clipright_unit=Window_GetElement(window,OxO8f06[20],true);var sel_overflow=Window_GetElement(window,OxO8f06[21],true);var tb_zindex=Window_GetElement(window,OxO8f06[22],true);var sel_pagebreakbefore=Window_GetElement(window,OxO8f06[23],true);var sel_pagebreakafter=Window_GetElement(window,OxO8f06[24],true);var outer=Window_GetElement(window,OxO8f06[25],true);var div_demo=Window_GetElement(window,OxO8f06[26],true);UpdateState=function UpdateState_Layout(){div_demo[OxO8f06[28]][OxO8f06[27]]=element[OxO8f06[28]][OxO8f06[27]];} ;SyncToView=function SyncToView_Layout(){sel_position[OxO8f06[29]]=element[OxO8f06[28]][OxO8f06[30]];sel_display[OxO8f06[29]]=element[OxO8f06[28]][OxO8f06[31]];if(Browser_IsWinIE()){sel_float[OxO8f06[29]]=element[OxO8f06[28]][OxO8f06[32]];} else {sel_float[OxO8f06[29]]=element[OxO8f06[28]][OxO8f06[33]];} ;sel_clear[OxO8f06[29]]=element[OxO8f06[28]][OxO8f06[34]];var arr=[OxO8f06[35],OxO8f06[36],OxO8f06[37],OxO8f06[38]];for(var Ox1fc=0;Ox1fc<arr[OxO8f06[39]];Ox1fc++){var Ox27=arr[Ox1fc];var Ox43=document.getElementById(OxO8f06[40]+Ox27);var Ox120=document.getElementById(OxO8f06[41]+Ox27+OxO8f06[42]);Ox120[OxO8f06[43]]=0;if(ParseFloatToString(element[OxO8f06[28]][Ox27])){Ox43[OxO8f06[29]]=ParseFloatToString(element[OxO8f06[28]][Ox27]);for(var i=0;i<Ox120[OxO8f06[44]][OxO8f06[39]];i++){var Ox142=Ox120[OxO8f06[44]][i][OxO8f06[29]];if(Ox142&&element[OxO8f06[28]][Ox27].indexOf(Ox142)!=-1){Ox120[OxO8f06[43]]=i;break ;} ;} ;} ;} ;var arr=[OxO8f06[35],OxO8f06[36],OxO8f06[45],OxO8f06[46]];for(var Ox1fc=0;Ox1fc<arr[OxO8f06[39]];Ox1fc++){var Ox27=arr[Ox1fc];var Ox601=OxO8f06[47]+Ox27.charAt(0).toUpperCase()+Ox27.substring(1);var Ox43=document.getElementById(OxO8f06[48]+Ox27);var Ox120=document.getElementById(OxO8f06[49]+Ox27+OxO8f06[42]);Ox120[OxO8f06[43]]=0;var Ox602;if(Browser_IsWinIE()){Ox602=element[OxO8f06[50]][Ox601];} else {Ox602=element[OxO8f06[28]][Ox601];} ;if(ParseFloatToString(Ox602)){Ox43[OxO8f06[29]]=ParseFloatToString(Ox602);for(var i=0;i<Ox120[OxO8f06[44]][OxO8f06[39]];i++){var Ox142=Ox120[OxO8f06[44]][i][OxO8f06[29]];if(Ox142&&Ox602.indexOf(Ox142)!=-1){Ox120[OxO8f06[43]]=i;break ;} ;} ;} ;} ;sel_overflow[OxO8f06[29]]=element[OxO8f06[28]][OxO8f06[51]];tb_zindex[OxO8f06[29]]=element[OxO8f06[28]][OxO8f06[52]];sel_pagebreakbefore[OxO8f06[29]]=element[OxO8f06[28]][OxO8f06[53]];sel_pagebreakafter[OxO8f06[29]]=element[OxO8f06[28]][OxO8f06[54]];} ;SyncTo=function SyncTo_Layout(element){element[OxO8f06[28]][OxO8f06[30]]=sel_position[OxO8f06[29]];element[OxO8f06[28]][OxO8f06[31]]=sel_display[OxO8f06[29]];if(Browser_IsWinIE()){element[OxO8f06[28]][OxO8f06[32]]=sel_float[OxO8f06[29]];} else {element[OxO8f06[28]][OxO8f06[33]]=sel_float[OxO8f06[29]];} ;element[OxO8f06[28]][OxO8f06[34]]=sel_clear[OxO8f06[29]];var arr=[OxO8f06[35],OxO8f06[36],OxO8f06[37],OxO8f06[38]];for(var Ox1fc=0;Ox1fc<arr[OxO8f06[39]];Ox1fc++){var Ox27=arr[Ox1fc];var Ox43=document.getElementById(OxO8f06[40]+Ox27);if(ParseFloatToString(Ox43.value)){element[OxO8f06[28]][Ox27]=ParseFloatToString(Ox43.value)+document.all(OxO8f06[41]+Ox27+OxO8f06[42])[OxO8f06[29]];} else {element[OxO8f06[28]][Ox27]=OxO8f06[0];} ;} ;var arr=[OxO8f06[35],OxO8f06[36],OxO8f06[45],OxO8f06[46]];for(var Ox1fc=0;Ox1fc<arr[OxO8f06[39]];Ox1fc++){var Ox27=arr[Ox1fc];var Ox601=OxO8f06[47]+Ox27.charAt(0).toUpperCase()+Ox27.substring(1);var Ox43=document.getElementById(OxO8f06[48]+Ox27);if(ParseFloatToString(Ox43.value)){element[OxO8f06[28]][Ox601]=ParseFloatToString(Ox43.value)+document.all(OxO8f06[49]+Ox27+OxO8f06[42])[OxO8f06[29]];} else {element[OxO8f06[28]][Ox601]=OxO8f06[0];} ;} ;element[OxO8f06[28]][OxO8f06[51]]=sel_overflow[OxO8f06[29]];element[OxO8f06[28]][OxO8f06[52]]=ParseFloatToString(tb_zindex.value);element[OxO8f06[28]][OxO8f06[53]]=sel_pagebreakbefore[OxO8f06[29]];element[OxO8f06[28]][OxO8f06[54]]=sel_pagebreakafter[OxO8f06[29]];} ;