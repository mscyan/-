window.onload=function(){
	var lis1=document.getElementById("s-tab-ul").getElementsByTagName("li");
	var lis2=document.getElementById("s-con-ul").getElementsByTagName("li");
	
	for (var i=0;i<lis1.length;i++) {
		lis1[i].id=i;
		lis2[0].style.display="block";
		lis1[i].onclick=function(){
			for (var j=0;j<lis1.length;j++) {
				lis1[j].className="s-tab-else";
				lis2[j].style.display="none";
			}
			lis1[this.id].className="s-tab-cur";
			lis2[this.id].style.display="block";
		}
	}
}