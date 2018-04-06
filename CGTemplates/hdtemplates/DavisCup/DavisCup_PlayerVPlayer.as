package  {
	
	import flash.display.MovieClip;
	import se.svt.caspar.template.CasparTemplate;
	import flash.text.TextField;
	import flash.text.TextFormat;
	import flash.text.Font;
	import flash.text.TextFieldType;
	import fl.transitions.Tween;
	import fl.transitions.easing.*;
	import flash.display.Shape;
	import flash.geom.Matrix;
	import flash.display.GradientType;
	import fl.transitions.TweenEvent;
	import flash.events.Event;
	import flash.text.TextFormatAlign;
	import flash.filters.*;
	import flash.external.ExternalInterface;
	import flash.utils.Timer;
	import flash.events.TimerEvent;
	import flash.display.Loader;
	import flash.events.IOErrorEvent;
	import flash.display.DisplayObject;
	import flash.net.URLRequest;
	import flash.sampler.Sample;
	import flash.globalization.NumberFormatter;
	import flash.globalization.LocaleID;
		
	public class DavisCup_PlayerVPlayer extends CasparTemplate{
		
		private var txtGroup:MovieClip = new MovieClip();
		public var icon1:MovieClip;
		public var icon2:MovieClip;
		
		public var giaidau:TextField = new TextField();
		public var vongdau:TextField = new TextField();
		public var PlayerName1:TextField = new TextField();
		public var PlayerName2:TextField = new TextField();
		public var thoigianDiaDiem:TextField = new TextField();			
						
		public function DavisCup_PlayerVPlayer() {
			// constructor code
			super();							
			this.txtGroup.addChild(giaidau);	
			this.txtGroup.addChild(vongdau);
			this.txtGroup.addChild(PlayerName1);
			this.txtGroup.addChild(PlayerName2);	
			this.txtGroup.addChild(thoigianDiaDiem);
			
			this.txtGroup.addChild(icon1);
			this.txtGroup.addChild(icon2);
			
			this.addChild(txtGroup);
			ExternalInterface.addCallback("UpdateData", UpdateData);
			ExternalInterface.addCallback("GetProperties", GetProperties);			
		}		
		
		private function Add(xmlStr:String, str:String, txt:TextField){
			xmlStr='<'+ str + ' id="'+ str + '"><data value="' + txt.text + '"/></' + str +'>';
			return xmlStr;
		}
		function GetProperties()
		{
			var xmlStr:String = "<Track_Property>";
			xmlStr +=Add(xmlStr, "giaidau", giaidau);
			xmlStr +=Add(xmlStr, "vongdau", vongdau);
			xmlStr +=Add(xmlStr, "PlayerName1", PlayerName1);
			xmlStr +=Add(xmlStr, "PlayerName2", PlayerName2);
			xmlStr +=Add(xmlStr, "thoigianDiaDiem", thoigianDiaDiem);					
			xmlStr += "</Track_Property>";
			
			ExternalInterface.call("Properties", xmlStr);
			return xmlStr;
		}
		function UpdateData(str:String)
		{
			var xml:XML = new XML(str);
			this.SetData(xml);
		}
		
		override public function SetData(xml:XML):void{
			for each (var element:XML in xml.children())
			{
				var property:String = element.@id;
				var data:String = element.data.@value;
				switch(property.toLowerCase())
				{						
					case "giaidau".toLowerCase():
						this.giaidau.text = data.toUpperCase();
						break;
					case "vongdau".toLowerCase():
						this.vongdau.text = data.toUpperCase();
						break;
					case "PlayerName1".toLowerCase():
						this.PlayerName1.text = data.toUpperCase();
						break;
					case "PlayerName2".toLowerCase():
						this.PlayerName2.text = data.toUpperCase();
						break;
					case "thoigianDiaDiem".toLowerCase():
						this.thoigianDiaDiem.text = data.toUpperCase();
						break;										
					case "icon1".toLowerCase():						
						var file:Loader = new Loader();
						file.contentLoaderInfo.addEventListener(Event.COMPLETE, onOpenImageCompleted);
						file.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR, onOpenImageError);
						file.load(new URLRequest(data));
						break;
					case "icon2".toLowerCase():						
						var file1:Loader = new Loader();
						file1.contentLoaderInfo.addEventListener(Event.COMPLETE, onOpenImageCompleted2);
						file1.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR, onOpenImageError2);
						file1.load(new URLRequest(data));
						break;					
				}
			}
		}
		public override function Play():void{
			gotoAndPlay('start');
		}
		public override function Stop():void{
			gotoAndPlay('stop');
		}		
		private function onOpenImageError(e:IOErrorEvent)
		{
			while(this.icon1.numChildren > 0)
				this.icon1.removeChildAt(0);
		}
		
		private function onOpenImageCompleted(e:Event)
		{
			var bmp:DisplayObject = e.currentTarget.content as DisplayObject;	
			bmp.width=300;
			bmp.height=300;
			this.icon1.addChild(bmp);
		}
		private function onOpenImageError2(e:IOErrorEvent)
		{
			while(this.icon2.numChildren > 0)
				this.icon2.removeChildAt(0);
		}
		
		private function onOpenImageCompleted2(e:Event)
		{
			var bmp:DisplayObject = e.currentTarget.content as DisplayObject;	
			bmp.width=300;
			bmp.height=300;
			this.icon2.addChild(bmp);
		}		
	}
	
}
