$(".content-bg-cyan .content-cyan .content-pic-cyan div img").mouseover(function(){
	var src = $(this).attr("src");
	var newsrc = src.substring(0,src.length-4)+"_hover.gif";
		$(this).attr("src",newsrc)
});
$(".content-bg-cyan .content-cyan .content-pic-cyan div img").mouseout(function(){
	var src = $(this).attr("src");
	var oldsrc = src.substring(0,src.length-10)+".gif";
	$(this).attr("src",oldsrc);
});