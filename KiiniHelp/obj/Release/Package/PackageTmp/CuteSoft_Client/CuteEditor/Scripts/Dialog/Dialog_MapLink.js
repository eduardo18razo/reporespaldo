var OxOcdbe=["inp_src","inp_title","inp_target","sel_protocol","btnbrowse","editor","","href","value","title","target","onclick","length","options","://",":","others","selectedIndex"];var inp_src=Window_GetElement(window,OxOcdbe[0],true);var inp_title=Window_GetElement(window,OxOcdbe[1],true);var inp_target=Window_GetElement(window,OxOcdbe[2],true);var sel_protocol=Window_GetElement(window,OxOcdbe[3],true);var btnbrowse=Window_GetElement(window,OxOcdbe[4],true);var obj=Window_GetDialogArguments(window);var editor=obj[OxOcdbe[5]];SyncToView();function SyncToView(){var src=obj[OxOcdbe[7]].replace(/$\s*/,OxOcdbe[6]);Update_sel_protocol(src);inp_src[OxOcdbe[8]]=src;if(obj[OxOcdbe[9]]){inp_title[OxOcdbe[8]]=obj[OxOcdbe[9]];} ;if(obj[OxOcdbe[10]]){inp_target[OxOcdbe[8]]=obj[OxOcdbe[10]];} ;} ;btnbrowse[OxOcdbe[11]]=function btnbrowse_onclick(){function Ox35d(Ox13e){if(Ox13e){inp_src[OxOcdbe[8]]=Ox13e;} ;} ;editor.SetNextDialogWindow(window);if(Browser_IsSafari()){editor.ShowSelectFileDialog(Ox35d,inp_src.value,inp_src);} else {editor.ShowSelectFileDialog(Ox35d,inp_src.value);} ;} ;function sel_protocol_change(){var src=inp_src[OxOcdbe[8]].replace(/$\s*/,OxOcdbe[6]);for(var i=0;i<sel_protocol[OxOcdbe[13]][OxOcdbe[12]];i++){var Ox142=sel_protocol[OxOcdbe[13]][i][OxOcdbe[8]];if(src.substr(0,Ox142.length).toLowerCase()==Ox142){src=src.substr(Ox142.length,src[OxOcdbe[12]]-Ox142[OxOcdbe[12]]);break ;} ;} ;var Ox449=src.indexOf(OxOcdbe[14]);if(Ox449!=-1){src=src.substr(Ox449+3,src[OxOcdbe[12]]-3-Ox449);} ;var Ox449=src.indexOf(OxOcdbe[15]);if(Ox449!=-1){src=src.substr(Ox449+1,src[OxOcdbe[12]]-1-Ox449);} ;var Ox44a=sel_protocol[OxOcdbe[8]];if(Ox44a==OxOcdbe[16]){Ox44a=OxOcdbe[6];} ;inp_src[OxOcdbe[8]]=Ox44a+src;} ;function Update_sel_protocol(src){var Ox44c=false;for(var i=0;i<sel_protocol[OxOcdbe[13]][OxOcdbe[12]];i++){var Ox142=sel_protocol[OxOcdbe[13]][i][OxOcdbe[8]];if(src.substr(0,Ox142.length).toLowerCase()==Ox142){if(sel_protocol[OxOcdbe[17]]!=i){sel_protocol[OxOcdbe[17]]=i;} ;Ox44c=true;break ;} ;} ;if(!Ox44c){sel_protocol[OxOcdbe[17]]=sel_protocol[OxOcdbe[13]][OxOcdbe[12]]-1;} ;} ;function insert_link(){var arr= new Array();arr[0]=inp_src[OxOcdbe[8]];if(inp_target[OxOcdbe[8]]){arr[1]=inp_target[OxOcdbe[8]];} ;if(inp_title[OxOcdbe[8]]){arr[2]=inp_title[OxOcdbe[8]];} ;Window_SetDialogReturnValue(window,arr);Window_CloseDialog(window);} ;