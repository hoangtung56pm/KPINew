if(!window.ComponentArt_Grid_Keyboard_Loaded){window.ComponentArt_Grid_KeyMovePageUp=function(){var oldHighlightedIndex=qqPa.KeyboardIndex;qqPa.PreviousPage();qqPa.KeyboardIndex=qqPa.CurrentPageIndex*qqPa.PageSize;ComponentArt_Grid_UpdateHighlights(oldHighlightedIndex);};window.ComponentArt_Grid_KeyMovePageDown=function(){var oldHighlightedIndex=qqPa.KeyboardIndex;qqPa.NextPage();qqPa.KeyboardIndex=qqPa.CurrentPageIndex*qqPa.PageSize;ComponentArt_Grid_UpdateHighlights(oldHighlightedIndex);};window.ComponentArt_Grid_KeyMoveHome=function(){var oldHighlightedIndex=qqPa.KeyboardIndex;qqPa.KeyboardIndex=qqPa.CurrentPageIndex*qqPa.PageSize;ComponentArt_Grid_UpdateHighlights(oldHighlightedIndex);};window.ComponentArt_Grid_KeyMoveEnd=function(){var oldHighlightedIndex=qqPa.KeyboardIndex;qqPa.KeyboardIndex=(qqPa.CurrentPageIndex+1)*qqPa.PageSize-1;ComponentArt_Grid_UpdateHighlights(oldHighlightedIndex);};window.ComponentArt_Grid_KeyMoveDown=function(){var oldKeyboardIndex=qqPa.KeyboardIndex;if(oldKeyboardIndex>=qqPa.RecordCount-1){return;};if(oldKeyboardIndex<qqPa.CurrentPageIndex*qqPa.PageSize||oldKeyboardIndex>=(qqPa.CurrentPageIndex+1)*qqPa.PageSize){qqPa.KeyboardIndex=qqPa.CurrentPageIndex*qqPa.PageSize;}else if(oldKeyboardIndex==(qqPa.CurrentPageIndex+1)*qqPa.PageSize-1){qqPa.NextPage();};qqPa.KeyboardIndex++;ComponentArt_Grid_UpdateHighlights(oldKeyboardIndex);};window.ComponentArt_Grid_KeyMoveUp=function(){var oldKeyboardIndex=qqPa.KeyboardIndex;if(oldKeyboardIndex<=0){return;};if(oldKeyboardIndex<qqPa.CurrentPageIndex*qqPa.PageSize||oldKeyboardIndex>=(qqPa.CurrentPageIndex+1)*qqPa.PageSize){oldKeyboardIndex=qqPa.CurrentPageIndex*qqPa.PageSize+1;}else if(oldKeyboardIndex==qqPa.CurrentPageIndex*qqPa.PageSize){qqPa.PreviousPage();};qqPa.KeyboardIndex--;ComponentArt_Grid_UpdateHighlights(oldKeyboardIndex);};window.ComponentArt_Grid_UpdateHighlights=function(oldHighlightedIndex){if(oldHighlightedIndex>0){var oldHighlightedRow=qqPa.Table.GetRow(oldHighlightedIndex);if(oldHighlightedRow){var qzwj=document.getElementById(qqPa.Id+'_row_'+oldHighlightedRow.qg10);if(qzwj&&qzwj.onmouseout){qzwj.onmouseout();};};};var newHighlightedRow=qqPa.Table.GetRow(qqPa.KeyboardIndex);if(newHighlightedRow){var qzwi=document.getElementById(qqPa.Id+'_row_'+newHighlightedRow.qg10);if(qzwi&&qzwi.onmouseover){qzwi.onmouseover();};};};window.ComponentArt_Grid_KeyboardSetToItem=function(grid,index){grid.KeyboardIndex=index;qqPa=grid;};window.ComponentArt_Grid_KeySelectItem=function(){var grid=qqPa,row=grid.Table.GetRow(grid.KeyboardIndex);if(row){grid.Select(row);};};window.ComponentArt_Grid.prototype.InitKeyboard=function(){qqPa=this;this.KeyboardIndex=0;ComponentArt_RegisterKeyHandler(this,'Enter','ComponentArt_Grid_KeySelectItem()');ComponentArt_RegisterKeyHandler(this,'(','ComponentArt_Grid_KeyMoveDown()');ComponentArt_RegisterKeyHandler(this,'&','ComponentArt_Grid_KeyMoveUp()');ComponentArt_RegisterKeyHandler(this,'$','ComponentArt_Grid_KeyMoveHome()');ComponentArt_RegisterKeyHandler(this,'#','ComponentArt_Grid_KeyMoveEnd()');ComponentArt_RegisterKeyHandler(this,'Ctrl+\'','ComponentArt_Grid_KeyMovePageDown()');ComponentArt_RegisterKeyHandler(this,'Ctrl+%','ComponentArt_Grid_KeyMovePageUp()');document.onkeydown=ComponentArt_HandleKeyPress;};window.ComponentArt_Grid_Keyboard_Loaded=true;};
