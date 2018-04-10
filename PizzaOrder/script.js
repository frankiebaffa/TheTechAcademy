//  Function to generate the receipt at bottom of page
function genReceipt(){
    var text1="";
    var text2="";
    var runTotal=0;
    var sizeTotal=0;

    //  Size
    var sizeArray=document.getElementsByClassName("size");
    for(var i=0;i<sizeArray.length;i++){
        if(sizeArray[i].checked){
            var selectedSize=sizeArray[i].value;
            text1=text1+selectedSize+" :"+"<br>";
        }
    };
    if(selectedSize==="Personal"){
        sizeTotal=6;
        text2="$"+text2+sizeTotal+"<br>";
    }else if(selectedSize==="Medium"){
        sizeTotal=10;
        text2="$"+text2+sizeTotal+"<br>";
    } else if(selectedSize==="Large"){
        sizeTotal=14;
        text2="$"+text2+sizeTotal+"<br>";
    }else if(selectedSize==="Extra Large"){
        sizeTotal=16;
        text2="$"+text2+sizeTotal+"<br>";
    }
    runTotal=sizeTotal;

    //  Sauce
    var sauceArray=document.getElementsByName("sauceRadio");
	for (var j=0;j<sauceArray.length;j++){
		if (sauceArray[j].checked){
			selectedSauce=sauceArray[j].value;
			text1=text1+selectedSauce+" :"+"<br>";
		}
	}
	text2=text2+"No Charge"+"<br>";

    //  Cheese
    var cheeseTotal=0;
	var selectedCheese=[];
	var cheeseArray=document.getElementsByName("cheeseRadio");
	for(var j=0;j<cheeseArray.length;j++){
		if(cheeseArray[j].checked){
			selectedCheese=cheeseArray[j].value;
		}
    };
	if(selectedCheese==="Extra Cheese"){
		cheeseTotal=3;
        text2=text2+"$"+cheeseTotal+"<br>";
	}else{
        cheeseTotal=0;
        text2=text2+"No Charge"+"<br>";
	};
	text1=text1+selectedCheese+" :"+"<br>";
	runTotal=(runTotal+cheeseTotal);

    //  Crust
    var crustTotal=0;
	var selectedCrust=[];
	var crustArray=document.getElementsByName("crustRadio");
	for(var j=0;j<crustArray.length;j++){
		if(crustArray[j].checked){
			selectedCrust=crustArray[j].value;
		}
    };
	if(selectedCrust==="Cheese Stuffed"){
		crustTotal=3;
        text2=text2+"$"+crustTotal+"<br>";
	}else{
        crustTotal=0;
        text2=text2+"No Charge"+"<br>";
	};
	text1=text1+selectedCrust+" :"+"<br>";
	runTotal=(runTotal+crustTotal);

    //  Meat
    var runTotal=runTotal;
	var meatTotal=0;
	var selectedMeat=[];
	var meatArray=document.getElementsByName("meatList");
	for(var j=0;j<meatArray.length;j++){
		if(meatArray[j].checked){
			selectedMeat.push(meatArray[j].value);
		}
	}
	var meatCount=selectedMeat.length;
	if(meatCount>1){
		meatTotal=(meatCount-1);
	}else{
		meatTotal=0;
	}
	runTotal=(runTotal+meatTotal);
	for(var j=0;j<selectedMeat.length;j++){
			text1=text1+selectedMeat[j]+" :"+"<br>";
			if(meatCount<=1){
				text2=text2+"No Charge"+"<br>";
				meatCount=meatCount-1;
			}else{
				text2=text2+"$"+1+"<br>";
				meatCount=meatCount-1;
			}
	};

    //  Veggie
    var veggieTotal=0;
	var selectedVeggie=[];
	var veggieArray=document.getElementsByName("veggieList");
	for(var j=0;j<veggieArray.length;j++){
		if(veggieArray[j].checked){
			selectedVeggie.push(veggieArray[j].value);
		}
	}
	var veggieCount=selectedVeggie.length;
	if(veggieCount>=2){
		veggieTotal=(veggieCount-1);
	}else{
		veggieTotal=0;
	}
	runTotal=(runTotal+veggieTotal);
	for(var j=0;j<selectedVeggie.length;j++){
			text1=text1+selectedVeggie[j]+" :"+"<br>";
			if(veggieCount<=1){
				text2=text2+"No Charge"+"<br>";
				veggieCount=veggieCount-1;
			}else{
				text2=text2+"$"+1+"<br>";
				veggieCount=veggieCount-1;
			}
	};

    //  print to receipt
    $("#clearButton").removeClass('invisible');
    $("#cart").removeClass('invisible');
    $("#orderButton").addClass('invisible');
    $("#orderForm").addClass('invisible');
    document.getElementById("showText1").innerHTML="<p>"+text1+"</p>";
    document.getElementById("showText2").innerHTML="<p>"+text2+"</p>";
    document.getElementById("totalPrice2").innerHTML="<h3>"+"$"+runTotal+".00"+"</h3>";
};

//  clear button function
function clearForm(){
    document.getElementById("orderForm").reset();
    $("#orderForm").removeClass('invisible');
    $("#orderButton").removeClass('invisible');
    $("#clearButton").addClass('invisible');
    $("#cart").addClass('invisible');
};
