// JScript File
/*********************************Menu Javascript***************
**Creator:Daniel 
**13/04/06
***************************************************************/
function getPos(el,sProp) { 
    var iPos = 0
    while (el!=null) {
        iPos+=el["offset" + sProp]
        el = el.offsetParent
    }
    return iPos

}

function MM_goToURL() { //v3.0
  var i, args=MM_goToURL.arguments; document.MM_returnValue = false;
  for (i=0; i<(args.length-1); i+=2) eval(args[i]+".location='"+args[i+1]+"'");
}
function JM_cc(ob){
var obj=MM_findObj(ob); if (obj) { 
obj.select();js=obj.createTextRange();js.execCommand("Copy");}
}

function MM_findObj(n, d) { //v4.0
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && document.getElementById) x=document.getElementById(n); return x;
}
//-->


menuPrefix = 'menu';  // Prefix that all menu layers must start with
                      // All layers with this prefix will be treated
                      // as a part of the menu system.

var menuTree, mouseMenu, hideTimer, doHide;
var ie4,ns4;

function init() {
  //ie4 = (document.all)?true:false;
  ie4 = (document.all)?true:false;
  ns4 = (document.layers)?true:false;
  document.onmousemove = mouseMove;
  if (ns4) { document.captureEvents(Event.MOUSEMOVE); }
}

function expandMenu(menuContainer,subContainer,menuLeft,menuTop)
{
    // Hide all submenus thats's not below the current level
    doHide = false;
    
    if (menuContainer != menuTree)
    {
        if (ie4)
        {
            var menuLayers = document.all.tags("DIV");
            
            for (i=0; i<menuLayers.length; i++)
            {
                if ((menuLayers[i].id.indexOf(menuContainer) != -1) && (menuLayers[i].id != menuContainer))
                {
                    hideObject(menuLayers[i].id);
                }
            }
        }
        else if (ns4)
        {
            for (i=0; i<document.layers.length; i++)
            {
                var menuLayer = document.layers[i];
                if ((menuLayer.id.indexOf(menuContainer) != -1) && (menuLayer.id != menuContainer))
                {
                    menuLayer.visibility = "hide";
                }
            }
        }
    }
    
    // If this is item has a submenu, display it, or it it's a toplevel menu, open it
    if (subContainer)
    {
        if ((menuLeft) && (menuTop))
        {
            positionObject(subContainer,menuLeft,menuTop);
            hideAll();
        }else{
            if (ie4)
            {
                positionObject(subContainer, document.getElementById[menuContainer].offsetWidth + document.getElementById[menuContainer].style.pixelLeft-10, mouseY);
            }else{
                positionObject(subContainer, document.layers[menuContainer].document.width + document.layers[menuContainer].left + 50, mouseY);
            }
        }
        showObject(subContainer);
        menuTree = subContainer;
    }
}

function showObject(obj) {
  if (ie4) { document.all[obj].style.visibility = "visible"; }
  else if (ns4) { document.layers[obj].visibility = "show";  }
}

function hideObject(obj) {
  if (ie4) { document.all[obj].style.visibility = "hidden"; }
  else if (ns4) { document.layers[obj].visibility = "hide"; }
}

function positionObject(obj,x,y) {
  if (ie4) {
    var foo = document.all[obj].style;
    foo.left = x;
    foo.top = y;
  }
  else if (ns4) {
    var foo = document.layers[obj];
    foo.left = x+40;
    foo.top = y;
   }
}

function hideAll() {
 if (ie4) {
    var menuLayers = document.all.tags("DIV");
    for (i=0; i<menuLayers.length; i++) {
      if (menuLayers[i].id.indexOf(menuPrefix) != -1) {
        hideObject(menuLayers[i].id);
      }
    }
  }
  else if (ns4) {
    for (i=0; i<document.layers.length; i++) {
      var menuLayer = document.layers[i];
      if (menuLayer.id.indexOf(menuPrefix) != -1) {
        hideObject(menuLayer.id);
      }
    }
  }
}

function hideMe(hide) {
    if (hide) {
        if (doHide) { hideAll(); }
    }
    else {
        doHide = true;
        hideTimer = window.setTimeout("hideMe(true);", 2000);
    }
}

function mouseMove(e) {
  if (ie4) { mouseY = window.event.y; }
  if (ns4) { mouseY = e.pageY; }
}

function itemHover(obj,src,text,style) {
  if (ns4) {
    var text = '<nobr><a href="' + src + '" class="' + style + '">' + text + '<\/a><\/nobr>'
    obj.document.open();
    obj.document.write(text);
    obj.document.close();
  }
}

onload = init;


/*****************************************************************
**function Check_login(type)
**add by daniel for check if login show menu...
**2006/05/25 if type="Y" then show else no show
*****************************************************************/
/*function Check_login(type)
{
if (type=="N"){
    //document.getElementById("ctl00_trAccount").style.display='';    
    document.getElementById("ctl00_trorderform").style.display='none';
    document.getElementById("ctl00_trfrequentma").style.display='none';    
    document.getElementById("ctl00_trchange").style.display='none';
    document.getElementById("ctl00_trtrip").style.display='none';
    document.getElementById("ctl00_trReceipt").style.display='none';
    document.getElementById("ctl00_trProfile").style.display='none';
    document.getElementById("ctl00_trCanceltrip").style.display='none';    
    document.getElementById("ctl00_trFrequent").style.display='';
    document.getElementById("ctl00_tablemenu1").style.height="72px";
    document.getElementById("ctl00_iframeMain").style.height="72px";
  }
else if (type=="Y"){
    //document.getElementById("ctl00_trAccount").style.display='none';
    document.getElementById("ctl00_trorderform").style.display='';
    document.getElementById("ctl00_trfrequentma").style.display=''; 
    document.getElementById("ctl00_trchange").style.display='';
    document.getElementById("ctl00_trtrip").style.display='';
    document.getElementById("ctl00_trCanceltrip").style.display=''; 
    document.getElementById("ctl00_trReceipt").style.display='';
    document.getElementById("ctl00_trProfile").style.display='';
    document.getElementById("ctl00_trFrequent").style.display='';
    document.getElementById("ctl00_tablemenu1").style.height="200px";
    document.getElementById("ctl00_iframeMain").style.height="200px";
}
else {
    //document.getElementById("ctl00_trAccount").style.display='';    
    document.getElementById("ctl00_trorderform").style.display='none';
    document.getElementById("ctl00_trfrequentma").style.display='none'; 
    document.getElementById("ctl00_trchange").style.display='none';
    document.getElementById("ctl00_trtrip").style.display='none';
    document.getElementById("ctl00_trCanceltrip").style.display='none'; 
    document.getElementById("ctl00_trReceipt").style.display='none';
    document.getElementById("ctl00_trProfile").style.display='none';
    document.getElementById("ctl00_trFrequent").style.display='';
    document.getElementById("ctl00_tablemenu1").style.height="72px";
    document.getElementById("ctl00_iframeMain").style.height="72px";
    }
}*/