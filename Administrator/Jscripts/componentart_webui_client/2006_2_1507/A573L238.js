if(!window.ComponentArt_Grid_Support_Loaded){window.ComponentArt_Grid_ResizeGrid=null;window.ComponentArt_Grid_ResizeDropHandler=function(qzAjk,x,y){qzff(qzAjk);qzff(ComponentArt_Grid_ResizeGrid.ResizeLeftObject);ComponentArt_Grid_ResizeGrid.ResizeLeftObject=null;if(ComponentArt_Grid_ResizeGrid.Levels[ComponentArt_Grid_ResizeGrid.ResizingLevel].NeedsColumnWidths){var oRowObj=ComponentArt_Grid_ResizeGrid.DownObject.parentNode;ComponentArt_Grid_ResizeGrid.FixColumnWidths(ComponentArt_Grid_ResizeGrid.ResizingLevel,oRowObj);};if(x<qzAfx(ComponentArt_Grid_ResizeGrid.OuterFrameDomObj)+ComponentArt_Grid_ResizeGrid.OuterFrameDomObj.offsetWidth){ComponentArt_Grid_ResizeGrid.ResizeColumn(ComponentArt_Grid_ResizeGrid.ResizingLevel,ComponentArt_Grid_ResizeGrid.ResizingDisplayColumn,x-ComponentArt_Grid_ResizeGrid.ResizeOffsetX-ComponentArt_Grid_ResizeGrid.ResizeStartX);};ComponentArt_Grid_ResizeGrid.FrameDomObj.style.cursor='';ComponentArt_Grid_ResizeGrid.IsResizing=false;ComponentArt_Grid_ResizeGrid.DownObject=null;ComponentArt_Grid_ResizeGrid.DownAction='NONE';ComponentArt_Grid_ResizeGrid=null;return false;};window.ComponentArt_Grid_RowDragBeginHandler=function(x,y){var qzAjk=document.createElement('DIV');qzAjk.style.position='absolute';qzAjk.style.cursor='default';qzAjk.style.zIndex=90210;qzAjk.style.left=x;qzAjk.style.top=y;if(ComponentArt_Grid_DragGrid.ItemDraggingCssClass){qzAjk.className=ComponentArt_Grid_DragGrid.ItemDraggingCssClass;};if(ComponentArt_Grid_DragGrid.ItemDraggingClientTemplateId){var qg34=ComponentArt_Grid_DragGrid.GetClientTemplate(ComponentArt_Grid_DragGrid.ItemDraggingClientTemplateId);if(qg34){qzAjk.innerHTML=ComponentArt_InstantiateClientTemplate(qg34,ComponentArt_Grid_DragGrid,ComponentArt_Grid_DragGrid.DraggingItem);};}else{qzAjk.style.width=ComponentArt_Grid_DragGrid.DraggingRowObj.offsetWidth+'px';qzAjk.style.height=ComponentArt_Grid_DragGrid.DraggingRowObj.offsetHeight+'px';var rowClone=ComponentArt_Grid_DragGrid.DraggingRowObj.cloneNode(true);qzAjk.innerHTML='<table width="100%"><tbody></tbody></table>';qzAjk.firstChild.firstChild.appendChild(rowClone);};document.body.insertBefore(qzAjk,document.body.firstChild);return qzAjk;};window.ComponentArt_Grid_RowDropHandler=function(qzAjk,x,y){qzff(qzAjk);var grid=ComponentArt_Grid_DragGrid,qznv=grid.get_events().getHandler('itemExternalDrop');if(grid.ExternalDropTargets&&qznv){var arTargets=grid.ExternalDropTargets.split(',');for(var qzba=0;qzba<arTargets.length;qzba++){var id=arTargets[qzba],qzbc;if((qzbc=window[id])&&qzbc.element){if(ComponentArt_IsMouseOnObject(qzbc.element,x,y)){var target=null;if(qzbc instanceof ComponentArt_TreeView){target=ComponentArt_TreeView_FindDropTarget(qzbc,qzbc.Nodes(),y);}else if(qzbc instanceof ComponentArt_Grid){target=qzbc.GetRowAt(x,y);}else{target=qzbc.element;};qznv(grid,new ComponentArt.Web.UI.GridItemExternalDropEventArgs(grid.DraggingItem,target,qzbc));break;};}else if(qzbc=document.getElementById(id)){if(ComponentArt_IsMouseOnObject(qzbc,x,y)){qznv(grid,new ComponentArt.Web.UI.GridItemExternalDropEventArgs(grid.DraggingItem,qzbc,qzbc.control));break;};};};};grid.DraggingRowObj=null;grid.DraggingItem=null;};window.ComponentArt_Grid_DragGrid=null;window.ComponentArt_Grid_DragBeginHandler=function(){var qg21=ComponentArt_Grid_DragGrid.Levels[ComponentArt_Grid_DragGrid.DraggingLevel],qg15=qg21.Table.Columns[qg21.Table.ColumnDisplayOrder[ComponentArt_Grid_DragGrid.DraggingDisplayColumn]],headingRowClass=qg21.ColumnHeadingRowCssClass,qzAjk=document.createElement('div');qzAjk.style.border='1px solid black';if(qg15.Width>0)qzAjk.style.width=qg15.Width+'px';qzAjk.className=headingRowClass+" "+qg15.EffectiveCssClass;qzAjk.innerHTML=ComponentArt_Grid_DragGrid.GetHeaderCellContent(ComponentArt_Grid_DragGrid.Levels[0],qg15);qzAjk.style.background='none';qzAjk.style.zIndex='90210';qzAjk.style.position='absolute';qzAjk.style.cursor='default';document.body.insertBefore(qzAjk,document.body.firstChild);if(cart_browser_ie){qzAjk.style.filter='alpha(opacity=50)';}else{qzAjk.style.opacity=0.5;qzAjk.style.setProperty('-moz-opacity',0.5,"");};return qzAjk;};window.ComponentArt_Grid_DragHandler=function(qzAjk,x,y){var qg21=ComponentArt_Grid_DragGrid.Levels[ComponentArt_Grid_DragGrid.DraggingLevel];if(ComponentArt_Grid_DragGrid.HeaderDomObj&&ComponentArt_IsOver(ComponentArt_Grid_DragGrid.HeaderDomObj,x,y)){qzAjk.IsOverHeader=true;if(qzAjk.OverColumnFeedbackObj){qzAjk.OverColumnFeedbackObj.style.visibility='hidden';};}else{qzAjk.IsOverHeader=false;qzAjk.OverColumn=ComponentArt_Grid_DragGrid.GetOverColumn(ComponentArt_Grid_DragGrid.DraggingLevel,x,y);if(qzAjk.OverColumn>=0&&ComponentArt_Grid_DragGrid.DraggingRowObj){var colNumFromBehind=0;for(var qzba=qg21.Table.ColumnDisplayOrder.length-1;qzba>=0&&qg21.Table.ColumnDisplayOrder[qzba]!=qzAjk.OverColumn;qzba--){if(qg21.Table.Columns[qg21.Table.ColumnDisplayOrder[qzba]].Visible){colNumFromBehind++;};};var colHeadingObj=ComponentArt_Grid_DragGrid.DraggingRowObj.childNodes[ComponentArt_Grid_DragGrid.DraggingRowObj.childNodes.length-1-colNumFromBehind];if(qg21.ColumnReorderIndicatorImageUrl){if(!qzAjk.OverColumnFeedbackObj){var imgObj=document.createElement('img');imgObj.src=qg21.ColumnReorderIndicatorImageUrl;imgObj.style.visibility='hidden';imgObj.style.position='absolute';imgObj.style.top='0px';imgObj.style.left='0px';imgObj.style.zIndex='90210';document.body.insertBefore(imgObj,document.body.firstChild);qzAjk.OverColumnFeedbackObj=imgObj;};qzAjk.OverColumnFeedbackObj.style.left=(qzAfx(colHeadingObj)-Math.round(qzAjk.OverColumnFeedbackObj.offsetWidth/2))+'px';qzAjk.OverColumnFeedbackObj.style.top=(qzAfw(colHeadingObj)-Math.round((qzAjk.OverColumnFeedbackObj.offsetHeight-colHeadingObj.offsetHeight)/2))+'px';qzAjk.OverColumnFeedbackObj.style.visibility='visible';};};};};window.ComponentArt_Grid_DropHandler=function(qzAjk,x,y){var bWasDragging=false;if(qzAjk){var bIsOverHeader=qzAjk.IsOverHeader,iOverColumn=qzAjk.OverColumn;if(qzAjk.OverColumnFeedbackObj){qzff(qzAjk.OverColumnFeedbackObj);};qzff(qzAjk);bWasDragging=true;};var qg21=ComponentArt_Grid_DragGrid.Levels[ComponentArt_Grid_DragGrid.DraggingLevel],draggingColumn=qg21.Table.ColumnDisplayOrder[ComponentArt_Grid_DragGrid.DraggingDisplayColumn];if(bIsOverHeader&&!ComponentArt_Grid_DragGrid.IsGroupDragging){ComponentArt_Grid_DragGrid.Group(draggingColumn,false);}else if(ComponentArt_Grid_DragGrid.IsGroupDragging&&!bIsOverHeader&&bWasDragging){ComponentArt_Grid_DragGrid.UnGroup();};if(iOverColumn>=0&&!bIsOverHeader&&!ComponentArt_Grid_DragGrid.IsGroupDragging){if(qg21.Table.Columns[draggingColumn].AllowReordering){var qzmo=0;for(var qzba=0;qzba<qg21.Table.ColumnDisplayOrder.length;qzba++){if(qg21.Table.ColumnDisplayOrder[qzba]==iOverColumn){qzmo=qzba;break;};};ComponentArt_Grid_DragGrid.MoveColumn(ComponentArt_Grid_DragGrid.DraggingLevel,draggingColumn,qzmo);};};ComponentArt_Grid_DragGrid.IsDragging=false;ComponentArt_Grid_DragGrid.IsGroupDragging=false;ComponentArt_Grid_DragGrid.DraggingRowObj=null;ComponentArt_Grid_DragGrid=null;};window.ComponentArt_Grid_SlideDelay=20;window.ComponentArt_Grid_ExpandingObj=null;window.ComponentArt_Grid_ExpandStartTime=null;window.ComponentArt_Grid_ExpandStep=function(qzeq,qzfu,qzeb){var qzcp=(new Date()).getTime()-ComponentArt_Grid_ExpandStartTime,qzcc=ComponentArt_SlidePortionCompleted(qzcp,qzfu,qzeb);if(qzcc==1){ComponentArt_Grid_ExpandingObj.style.height=qzeq+'px';if(!cart_browser_ie)ComponentArt_Grid_ExpandingObj.style.height='';ComponentArt_Grid_ExpandingObj=null;}else{ComponentArt_Grid_ExpandingObj.style.height=Math.max(1,Math.floor(qzeq*qzcc))+'px';setTimeout('ComponentArt_Grid_ExpandStep('+qzeq+','+qzfu+','+qzeb+');',ComponentArt_Grid_SlideDelay);};};window.ComponentArt_Grid_Expand=function(grid,domObj,qqZj){if(ComponentArt_Grid_ExpandingObj){return;};if(ComponentArt_Grid_CollapsingObj==domObj){return;};var qzlc=domObj.cloneNode(true);qzlc.style.visibility='hidden';qzlc.style.display='block';qzlc.style.height='';document.body.insertBefore(qzlc,document.body.firstChild);var qzeq=qzlc.offsetHeight;qzff(qzlc);var qzfu=qqZj?0:grid.ExpandDuration;ComponentArt_Grid_ExpandingObj=domObj;ComponentArt_Grid_ExpandingObj.style.height='1px';ComponentArt_Grid_ExpandingObj.style.width='100%';ComponentArt_Grid_ExpandingObj.style.overflow='hidden';ComponentArt_Grid_ExpandingObj.style.display='';if(ComponentArt_Grid_ExpandingObj.parentNode.parentNode.style.display=='none'){ComponentArt_Grid_ExpandingObj.parentNode.parentNode.style.display='';};if((grid.ExpandTransition>0||grid.ExpandTransitionCustomFilter)&&qzfu>0&&cart_browser_transitions){if(!domObj.ExpandTransitionFilterDefined){var qzdi=EffectiveTransitionString(grid.ExpandTransition,grid.ExpandTransitionCustomFilter);domObj.ExpandTransitionFilterIndex=domObj.filters.length;domObj.ExpandTransitionFilterDefined=true;domObj.runtimeStyle.filter=domObj.currentStyle.filter+' '+qzdi;};domObj.style.visibility='hidden';domObj.filters[domObj.ExpandTransitionFilterIndex].apply();domObj.style.visibility='visible';domObj.filters[domObj.ExpandTransitionFilterIndex].play(qzfu/1000);};ComponentArt_Grid_ExpandStartTime=(new Date()).getTime();ComponentArt_Grid_ExpandStep(qzeq,qzfu,grid.ExpandSlide);};window.ComponentArt_Grid_CollapsingObj=null;window.ComponentArt_Grid_CollapseStartTime=null;window.ComponentArt_Grid_CollapseStep=function(qzky,qzfu,qzeb){var qzcp=(new Date()).getTime()-ComponentArt_Grid_CollapseStartTime,qzcc=ComponentArt_SlidePortionCompleted(qzcp,qzfu,qzeb);if(qzcc==1){if(ComponentArt_Grid_CollapsingObj.IsGroup){ComponentArt_Grid_CollapsingObj.style.display='none';}else{ComponentArt_Grid_CollapsingObj.parentNode.parentNode.style.display='none';};ComponentArt_Grid_CollapsingObj=null;}else{ComponentArt_Grid_CollapsingObj.style.height=Math.ceil((1-qzcc)*qzky)+'px';setTimeout('ComponentArt_Grid_CollapseStep('+qzky+','+qzfu+','+qzeb+');',ComponentArt_Grid_SlideDelay);};};window.ComponentArt_Grid_Collapse=function(grid,domObj,qqZj){if(ComponentArt_Grid_CollapsingObj){return;};if(ComponentArt_Grid_ExpandingObj==domObj){return;};ComponentArt_Grid_CollapsingObj=domObj;ComponentArt_Grid_CollapsingObj.style.overflow='hidden';var qzfu=qqZj?0:grid.CollapseDuration;if((grid.CollapseTransition>0||grid.CollapseTransitionCustomFilter)&&qzfu>0&&cart_browser_transitions){if(!domObj.CollapseTransitionFilterDefined){var qzcy=EffectiveTransitionString(grid.CollapseTransition,grid.CollapseTransitionCustomFilter);domObj.CollapseTransitionFilterIndex=domObj.filters.length;domObj.CollapseTransitionFilterDefined=true;domObj.runtimeStyle.filter=domObj.currentStyle.filter+' '+qzcy;};domObj.style.visibility='visible';domObj.filters[qzn.CollapseTransitionFilterIndex].apply();domObj.style.visibility='hidden';domObj.filters[qzn.CollapseTransitionFilterIndex].play(qzfu/1000);};if(grid.CollapseSlide==0&&qzfu>0){setTimeout('ComponentArt_Grid_CollapseStartTime=(new Date()).getTime();ComponentArt_Grid_CollapseStep(0,0,0);',qzfu);}else{ComponentArt_Grid_CollapseStartTime=(new Date()).getTime();ComponentArt_Grid_CollapseStep(domObj.offsetHeight,qzfu,grid.CollapseSlide);};};window.ComponentArt_Grid_ExpandGroupStep=function(qzeq,qzfu,qzeb){var qzcp=(new Date()).getTime()-ComponentArt_Grid_ExpandStartTime,qzcc=ComponentArt_SlidePortionCompleted(qzcp,qzfu,qzeb),newOffset=qzcc==1?'':'-'+Math.ceil((1-qzcc)*qzeq)+'px';for(var oTBodyElement=ComponentArt_Grid_ExpandingObj.nextSibling;oTBodyElement!=null;oTBodyElement=oTBodyElement.nextSibling){for(var oTrElement=oTBodyElement.firstChild;oTrElement!=null;oTrElement=oTrElement.nextSibling){oTrElement.style.top=newOffset;};};if(qzcc==1){ComponentArt_Grid_ExpandingObj=null;}else{setTimeout('ComponentArt_Grid_ExpandGroupStep('+qzeq+','+qzfu+','+qzeb+');',ComponentArt_Grid_SlideDelay);};};window.ComponentArt_Grid_ExpandGroup=function(grid,groupDom){var qzeq=groupDom.offsetHeight,qzfu=grid.ExpandDuration;for(var oTBodyElement=groupDom.nextSibling;oTBodyElement!=null;oTBodyElement=oTBodyElement.nextSibling){for(var oTrElement=oTBodyElement.firstChild;oTrElement!=null;oTrElement=oTrElement.nextSibling){oTrElement.style.position='relative';oTrElement.style.top='-'+qzeq+'px';};oTBodyElement.style.display='';};groupDom.style.visibility='visible';ComponentArt_Grid_ExpandingObj=groupDom;ComponentArt_Grid_ExpandStartTime=(new Date()).getTime();ComponentArt_Grid_ExpandGroupStep(qzeq,qzfu,grid.ExpandSlide);};window.ComponentArt_Grid_CollapseGroupStep=function(qzeq,qzfu,qzeb){var qzcp=(new Date()).getTime()-ComponentArt_Grid_CollapseStartTime,qzcc=ComponentArt_SlidePortionCompleted(qzcp,qzfu,qzeb),newOffset;if(qzcc==1){ComponentArt_Grid_CollapsingObj.style.display='none';newOffset='';}else{newOffset='-'+Math.ceil(qzcc*qzeq)+'px';};for(var oTBodyElement=ComponentArt_Grid_CollapsingObj.nextSibling;oTBodyElement!=null;oTBodyElement=oTBodyElement.nextSibling){for(var oTrElement=oTBodyElement.firstChild;oTrElement!=null;oTrElement=oTrElement.nextSibling){oTrElement.style.top=newOffset;};};if(qzcc==1){ComponentArt_Grid_CollapsingObj=null;}else{setTimeout('ComponentArt_Grid_CollapseGroupStep('+qzeq+','+qzfu+','+qzeb+');',ComponentArt_Grid_SlideDelay);};};window.ComponentArt_Grid_CollapseGroup=function(grid,groupDom){var qzeq=groupDom.offsetHeight,qzfu=grid.CollapseDuration;for(var oTBodyElement=groupDom.nextSibling;oTBodyElement!=null;oTBodyElement=oTBodyElement.nextSibling){for(var oTrElement=oTBodyElement.firstChild;oTrElement!=null;oTrElement=oTrElement.nextSibling){oTrElement.style.position='relative';};};groupDom.style.visibility='visible';ComponentArt_Grid_CollapsingObj=groupDom;ComponentArt_Grid_CollapseStartTime=(new Date()).getTime();ComponentArt_Grid_CollapseGroupStep(qzeq,qzfu,grid.CollapseSlide);};window.ComponentArt_Grid_Popup=null;window.ComponentArt_Grid_PopupShow=function(grid,qg24,x,isRightX,y,isBottomY,sTemplateId){if(!ComponentArt_Grid_Popup){ComponentArt_Grid_Popup=document.createElement('div');ComponentArt_Grid_Popup.style.zIndex=9999;ComponentArt_Grid_Popup.style.position='absolute';ComponentArt_Grid_Popup.style.visibility='hidden';document.body.insertBefore(ComponentArt_Grid_Popup,document.body.firstChild);};var sText;if(sTemplateId){var qg34=grid.GetClientTemplate(sTemplateId);if(qg34){sText=ComponentArt_InstantiateClientTemplate(qg34,grid,qg24);}else{sText='Template not found: '+grid.SliderPopupClientTemplateId;};}else{ComponentArt_Grid_Popup.style.border='1px solid black';ComponentArt_Grid_Popup.style.padding='10px';ComponentArt_Grid_Popup.style.width='200px';ComponentArt_Grid_Popup.style.fontFamily='verdana';ComponentArt_Grid_Popup.style.fontSize='12px';ComponentArt_Grid_Popup.style.fontWeight='bold';ComponentArt_Grid_Popup.style.textAlign='center';ComponentArt_Grid_Popup.style.backgroundColor='#ffffff';if(ComponentArt_Grid_ScrollObject){sText='Record '+(qg24.Index+1)+' of '+grid.RecordCount;}else{sText='Page '+(qg24.PageIndex+1)+' of '+grid.PageCount;};};ComponentArt_Grid_Popup.innerHTML=sText;ComponentArt_Grid_Popup.style.left=(isRightX?(x-ComponentArt_Grid_Popup.offsetWidth):x)+'px';ComponentArt_Grid_Popup.style.top=(isBottomY?(y-ComponentArt_Grid_Popup.offsetHeight):y)+'px';ComponentArt_Grid_Popup.style.visibility='visible';};window.ComponentArt_Grid_PopupHide=function(){qzff(ComponentArt_Grid_Popup);ComponentArt_Grid_Popup=null;};window.ComponentArt_Grid_SliderGrid=null;window.ComponentArt_Grid_SliderObject=null;window.ComponentArt_Grid_SliderStartX=null;window.ComponentArt_Grid_SliderStartEffectiveX=null;window.ComponentArt_Grid_SliderPopupX=null;window.ComponentArt_Grid_SliderPopupY=null;window.ComponentArt_Grid_SliderPage=0;window.ComponentArt_Grid_HandleSlideDone=function(qzim){ComponentArt_CancelEvent(qzim);ComponentArt_Grid_PopupHide();if(ComponentArt_Grid_SliderPage!=ComponentArt_Grid_SliderGrid.CurrentPageIndex){ComponentArt_Grid_SliderGrid.Page(ComponentArt_Grid_SliderPage);};document.onmousemove=null;document.onmouseup=null;return false;};window.ComponentArt_Grid_HandleSlide=function(qzim){ComponentArt_CancelEvent(qzim);var qzp=cart_browser_ie?event.clientX+(document.documentElement&&document.documentElement.scrollLeft?document.documentElement.scrollLeft:document.body.scrollLeft):qzim.pageX,effectiveX=qzp-ComponentArt_Grid_SliderStartX,finalX=ComponentArt_Grid_SliderStartEffectiveX+effectiveX;ComponentArt_Grid_SliderPage=Math.max(0,Math.min(ComponentArt_Grid_SliderGrid.PageCount-1,Math.round(((finalX)*ComponentArt_Grid_SliderGrid.PageCount)/(ComponentArt_Grid_SliderObject.parentNode.offsetWidth))));ComponentArt_Grid_SliderObject.style.left=Math.max(0,Math.min(finalX,ComponentArt_Grid_SliderObject.parentNode.offsetWidth-ComponentArt_Grid_SliderObject.offsetWidth))+'px';var qg24;if(ComponentArt_Grid_SliderGrid.Levels[0].NumGroupings>0){var group=ComponentArt_Grid_SliderGrid.Levels[0].Groups[ComponentArt_Grid_SliderPage*ComponentArt_Grid_SliderGrid.GroupingPageSize];if(group){qg24=ComponentArt_Grid_SliderGrid.Table.GetRow(group.Rows[0],group);}else{qg24=new Object();qg24.GetMember=function(){return'No data';};qg24.PageIndex=ComponentArt_Grid_SliderPage;qg24.Index=ComponentArt_Grid_SliderPage*ComponentArt_Grid_SliderGrid.GroupingPageSize;};}else{qg24=ComponentArt_Grid_SliderGrid.Table.GetRow(ComponentArt_Grid_SliderPage*ComponentArt_Grid_SliderGrid.PageSize);if(!qg24){qg24=new Object();qg24.GetMember=function(){return'No data';};qg24.PageIndex=ComponentArt_Grid_SliderPage;qg24.Index=ComponentArt_Grid_SliderPage*ComponentArt_Grid_SliderGrid.PageSize;};};ComponentArt_Grid_PopupShow(ComponentArt_Grid_SliderGrid,qg24,ComponentArt_Grid_SliderPopupX,false,ComponentArt_Grid_SliderPopupY,true,ComponentArt_Grid_SliderGrid.SliderPopupClientTemplateId);};window.ComponentArt_Grid_HandleSlideClick=function(qzim,qzgx,grid){var mouseX=cart_browser_ie?event.clientX+document.body.scrollLeft:qzim.pageX,sliderX=qzAfx(qzgx),offsetX=mouseX-sliderX;if(offsetX>=grid.SliderPosition){grid.NextPage();}else{grid.PreviousPage();};return false;};window.ComponentArt_Grid_HandleSlideStart=function(qzim,qzgx,grid){ComponentArt_CancelEvent(qzim);var qzp=cart_browser_ie?event.clientX+(document.documentElement&&document.documentElement.scrollLeft?document.documentElement.scrollLeft:document.body.scrollLeft):qzim.pageX;ComponentArt_Grid_SliderStartX=qzp;ComponentArt_Grid_SliderStartEffectiveX=qzgx.style.left?parseInt(qzgx.style.left):0;ComponentArt_Grid_SliderObject=qzgx;ComponentArt_Grid_SliderGrid=grid;ComponentArt_Grid_SliderPage=grid.CurrentPageIndex;ComponentArt_Grid_SliderPopupX=qzAfx(grid.FrameDomObj)+grid.SliderPopupOffsetX;ComponentArt_Grid_SliderPopupY=qzAfw(ComponentArt_Grid_SliderObject)-20;document.onmousemove=ComponentArt_Grid_HandleSlide;document.onmouseup=ComponentArt_Grid_HandleSlideDone;};window.ComponentArt_Grid_ScrollGrid=null;window.ComponentArt_Grid_ScrollObject=null;window.ComponentArt_Grid_ScrollStartY=null;window.ComponentArt_Grid_ScrollStartEffectiveX=null;window.ComponentArt_Grid_ScrollDirection=null;window.ComponentArt_Grid_ScrollRecord=0;window.ComponentArt_Grid_HandleScrollDone=function(qzim){ComponentArt_Grid_PopupHide();ComponentArt_Grid_ScrollGrid.ScrollTo(ComponentArt_Grid_ScrollRecord);ComponentArt_Grid_ScrollGrid=null;ComponentArt_Grid_ScrollObject=null;document.onmousemove=null;document.onmouseup=null;};window.ComponentArt_Grid_HandleScrollStart=function(qzim,qzgx,grid){ComponentArt_CancelEvent(qzim);var qzf=cart_browser_ie?event.clientY+(document.documentElement&&document.documentElement.scrollTop?document.documentElement.scrollTop:document.body.scrollTop):qzim.pageY;ComponentArt_Grid_ScrollStartY=qzf;ComponentArt_Grid_ScrollStartEffectiveY=qzgx.style.top?parseInt(qzgx.style.top):0;ComponentArt_Grid_ScrollObject=qzgx;ComponentArt_Grid_ScrollGrid=grid;document.onmousemove=ComponentArt_Grid_HandleScroll;document.onmouseup=ComponentArt_Grid_HandleScrollDone;ComponentArt_Grid_ScrollDirection=1;};window.ComponentArt_Grid_HandleScrollPage=function(qzim,qzgx,grid){ComponentArt_CancelEvent(qzim);var qzf=cart_browser_ie?event.clientY+(document.documentElement&&document.documentElement.scrollTop?document.documentElement.scrollTop:document.body.scrollTop):qzim.pageY,offsetY=qzf-qzAfw(qzgx),offsetTop=parseInt(qzgx.firstChild.style.top);if(offsetY>offsetTop){if(grid.RecordOffset+grid.PageSize>=grid.RecordCount-grid.PageSize){grid.ScrollTo(grid.RecordCount-grid.PageSize);}else{grid.ScrollBy(grid.PageSize);};}else{if(grid.RecordOffset<grid.PageSize){grid.ScrollTo(0);}else{grid.ScrollBy(grid.PageSize*-1);};};};window.ComponentArt_Grid_HandleScroll=function(qzim){ComponentArt_CancelEvent(qzim);var qzf=cart_browser_ie?event.clientY+(document.documentElement&&document.documentElement.scrollTop?document.documentElement.scrollTop:document.body.scrollTop):qzim.pageY,effectiveY=qzf-ComponentArt_Grid_ScrollStartY,finalY=ComponentArt_Grid_ScrollStartEffectiveY+effectiveY,percentage=Math.max(0,Math.min(finalY,ComponentArt_Grid_ScrollObject.parentNode.offsetHeight-ComponentArt_Grid_ScrollObject.offsetHeight));ComponentArt_Grid_ScrollObject.style.top=Math.max(0,Math.min(finalY,ComponentArt_Grid_ScrollObject.parentNode.offsetHeight-ComponentArt_Grid_ScrollObject.offsetHeight))+'px';var newScrollRecord=Math.max(0,Math.min(ComponentArt_Grid_ScrollGrid.RecordCount-ComponentArt_Grid_ScrollGrid.PageSize,Math.round((finalY/ComponentArt_Grid_ScrollObject.parentNode.offsetHeight)*ComponentArt_Grid_ScrollGrid.RecordCount)));if(ComponentArt_Grid_ScrollDirection){ComponentArt_Grid_ScrollDirection=!(newScrollRecord<ComponentArt_Grid_ScrollRecord);}else{ComponentArt_Grid_ScrollDirection=(newScrollRecord>ComponentArt_Grid_ScrollRecord);};ComponentArt_Grid_ScrollRecord=newScrollRecord;var showRecord=ComponentArt_Grid_ScrollDirection?Math.min(ComponentArt_Grid_ScrollGrid.RecordCount-1,ComponentArt_Grid_ScrollRecord+ComponentArt_Grid_ScrollGrid.PageSize-1):ComponentArt_Grid_ScrollRecord,qg24;if(ComponentArt_Grid_ScrollGrid.Levels[0].NumGroupings>0){var group=ComponentArt_Grid_ScrollGrid.Levels[0].Groups[showRecord];qg24=ComponentArt_Grid_ScrollGrid.Table.GetRow(group.Rows[0],group);}else{qg24=ComponentArt_Grid_ScrollGrid.Table.GetRow(showRecord);if(!qg24){qg24=new Object();qg24.GetMember=function(){return'No data';};qg24.Index=ComponentArt_Grid_ScrollRecord;qg24.PageIndex=Math.floor(ComponentArt_Grid_ScrollRecord/ComponentArt_Grid_ScrollGrid.PageSize);};};if(ComponentArt_Grid_ScrollGrid.ScrollPopupClientTemplateId){var popupX=qzAfx(ComponentArt_Grid_ScrollObject)-20,popupY=qzAfw(ComponentArt_Grid_ScrollObject)+Math.round(ComponentArt_Grid_ScrollObject.offsetHeight/2);ComponentArt_Grid_PopupShow(ComponentArt_Grid_ScrollGrid,qg24,popupX,true,popupY,false,ComponentArt_Grid_ScrollGrid.ScrollPopupClientTemplateId);};};window.ComponentArt_IsOver=function(domObj,x,y){var ox=qzAfx(domObj),oy=qzAfw(domObj),ow=domObj.offsetWidth,oh=domObj.offsetHeight;return(x>=ox&&x<=ox+ow&&y>=oy&&y<=oy+oh);};window.ComponentArt_Grid_Support_Loaded=true;};