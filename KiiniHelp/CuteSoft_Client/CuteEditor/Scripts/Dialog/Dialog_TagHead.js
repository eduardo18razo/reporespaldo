var OxO48e9=["top","opener","_dialog_arguments","document","dialogArguments","editor","window","element","changed","propertyName","value","checked","trim","prototype",""];function Window_GetDialogTop(Ox1a8){return Ox1a8[OxO48e9[0]];} ;function Window_FindDialogArguments(Ox1a8){var Ox23c=Ox1a8[OxO48e9[0]];try{var Ox23d=Ox23c[OxO48e9[1]];if(Ox23d&&Ox23d[OxO48e9[3]][OxO48e9[2]]){return Ox23d[OxO48e9[3]][OxO48e9[2]];} ;} catch(x){} ;if(Ox23c[OxO48e9[3]][OxO48e9[2]]){return Ox23c[OxO48e9[3]][OxO48e9[2]];} ;if(Ox23c[OxO48e9[4]]){return Ox23c[OxO48e9[4]];} ;return Ox23c[OxO48e9[3]][OxO48e9[2]];} ;var arg=Window_FindDialogArguments(window);var editor=arg[OxO48e9[5]];var editwin=arg[OxO48e9[6]];var editdoc=arg[OxO48e9[3]];var element=arg[OxO48e9[7]];var syncingtoview=false;Window_GetDialogTop(window)[OxO48e9[8]]=Window_GetDialogTop(window)[OxO48e9[8]]||arg[OxO48e9[8]];function OnPropertyChange(){if(syncingtoview){return ;} ;var Ox333=Event_GetEvent();if(Ox333[OxO48e9[9]]!=OxO48e9[10]&&Ox333[OxO48e9[9]]!=OxO48e9[11]){return ;} ;FireUIChanged();} ;function FireUIChanged(){Window_GetDialogTop(window)[OxO48e9[8]]=true;SyncTo(element);UpdateState();} ;function SyncToViewInternal(){syncingtoview=true;try{SyncToView();UpdateState();} finally{syncingtoview=false;} ;} ;String[OxO48e9[13]][OxO48e9[12]]=function (){return this.replace(/(^\s*)|(\s*$)/g,OxO48e9[14]);} ;function UpdateState(){} ;function SyncTo(element){} ;function SyncToView(){} ;