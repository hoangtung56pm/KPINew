if ("\x75ndefi\x6e\x65d"==typeof(RadDockNamespace)){RadDockNamespace=new Object(); }Object.L= function (object,i1g){for (var I1g in i1g){object[I1g]=i1g[I1g]; }} ; RadDockNamespace.l2= function (n,o1h,O1h){if (n.attachEvent){n.attachEvent("on"+o1h,O1h); }else if (n.addEventListener){n.addEventListener(o1h,O1h, false); }} ; RadDockNamespace.l1a= function (n,o1h,O1h){if (n.detachEvent){n.detachEvent("\157\x6e"+o1h,O1h); }else if (n.removeEventListener){n.removeEventListener(o1h,O1h, false); }} ; RadDockNamespace.I13= function (eventArgs){if (!eventArgs)return null; if (eventArgs.srcElement)return eventArgs.srcElement; if (eventArgs.target)return eventArgs.target; return null; } ; RadDockNamespace.Ig= function (){if (document.documentElement && document.documentElement.scrollTop){return document.documentElement.scrollTop; }else {return document.body.scrollTop; }} ; RadDockNamespace.ig= function (){if (document.documentElement && document.documentElement.scrollLeft){return document.documentElement.scrollLeft; }else {return document.body.scrollLeft; }} ; RadDockNamespace.l1h= function (i1h,defaultValue){if (!defaultValue)defaultValue=0; var I1h=parseInt(i1h); return (isNaN(I1h)?defaultValue:I1h); } ; RadDockNamespace.l1= function (o1i){var O1i=0; if (document.all && "\x43SS1\x43\x6fmpat"==document.compatMode){var l1i=o1i.offsetHeight; O1i=(l1i-parseInt(o1i.style.height)); if (O1i>0){var i1i=(parseInt(o1i.style.height)-O1i); if (i1i>0)o1i.style.height=i1i+"px"; }}return O1i; };RadControlsNamespace.AppendStyleSheet= function (I1i,o1j,O1j){if (!O1j){return; }if (!I1i){document.write("\074"+"\x6cink"+"\x20rel=\047\x73tyle\x73\150e\x65t\047\x20type\x3d\x27te\x78\x74\x2fcss\x27\x20hr\x65f=\047"+O1j+"\x27 />"); }else {var l1j=document.createElement("L\x49\x4eK"); l1j.rel="\x73tyleshe\x65\x74"; l1j.type="text/c\x73\x73"; l1j.href=O1j; document.getElementById(o1j+"\123ty\x6c\x65Sheet\x48\x6flder").appendChild(l1j); }} ;