

//su dung cho ham check all
function IsMatch(id,pattern) {
    return true; 
//    var regularExpresssion = new RegExp(pattern); 
//    
//    if(id.match(regularExpresssion)) return true; 
//    else return false; 
}

//su dung cho ham check all
function IsCheckBox(chk) 
{
    if(chk.type == 'checkbox') 
    {
        return true;
    }
    else 
    {
        return false;
    }
}

//ham check all
function Check(parentChk,gridName) 
{
    var elements =  document.getElementsByTagName("INPUT");
    
    for(i=0; i<elements.length;i++) 
    {
        if (parentChk.checked == true) {
            
            if( IsCheckBox(elements[i]) &&  IsMatch(elements[i].id,gridName)) 
            {
                elements[i].checked = true; 
            }         
        }
        else 
        {
            if( IsCheckBox(elements[i]) &&  IsMatch(elements[i].id,gridName)) 
            {
                elements[i].checked = false; 
            } 
        }  
    }
    
}
//ham doi mau
function highlightChkBxRow(chkbx) 
{
    
    if (chkbx.id.indexOf ('chkVisible') != -1) {
        
	    if (chkbx.checked == true)
		    {
		    chkbx.parentElement.parentElement.style.backgroundColor='#F5EDED';
		    chkbx.parentElement.parentElement.style.color = '#000000';
		  
		    }
		    else {
		    
		    chkbx.parentElement.parentElement.style.backgroundColor='#FFFFFF';
		    chkbx.parentElement.parentElement.style.color='#000000'; 
		    }
	    }
    else
	{
	    var frm = document.forms[0];
	    for (h = 0; h < frm.length; h++)
		{
		    if (frm.elements[h].id.indexOf ('DeleteThis') != -1)
			{
			    if (chkbx.id.indexOf ('chkAll') != -1 && chkbx.checked) 
				{
				    frm.elements[h].parentElement.parentElement.style.backgroundColor='#F5EDED';
				    frm.elements[h].parentElement.parentElement.style.color='#000000';			
				}
			    else
				{
				    frm.elements[h].parentElement.parentElement.style.backgroundColor='#FFFFFF';
				    frm.elements[h].parentElement.parentElement.style.color='#000000';				
				}
			}
		} 
    }
}
         
    