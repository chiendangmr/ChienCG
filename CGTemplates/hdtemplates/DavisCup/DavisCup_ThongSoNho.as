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
		
	public class DavisCup_ThongSoNho extends CasparTemplate{
		
		private var txtGroup:MovieClip = new MovieClip();
		public var icon1:MovieClip;
		public var icon2:MovieClip;
		
		public var player1:TextField = new TextField();
		public var player2:TextField = new TextField();
		public var thongso:TextField = new TextField();
		public var giatriThongso1:TextField = new TextField();
		public var giatriThongso2:TextField = new TextField();		
						
		public function DavisCup_ThongSoNho() {
			// constructor code
			super();							
			this.txtGroup.addChild(player1);	
			this.txtGroup.addChild(player2);
			this.txtGroup.addChild(thongso);
			this.txtGroup.addChild(giatriThongso1);	
			this.txtGroup.addChild(giatriThongso2);			
					
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
			xmlStr +=Add(xmlStr, "player1", player1);
			xmlStr +=Add(xmlStr, "player2", player2);
			xmlStr +=Add(xmlStr, "thongso", thongso);
			xmlStr +=Add(xmlStr, "giatriThongso1", giatriThongso1);
			xmlStr +=Add(xmlStr, "giatriThongso2", giatriThongso2);					
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
					case "player1".toLowerCase():
						this.player1.text = data.toUpperCase();
						break;
					case "player2".toLowerCase():
						this.player2.text = data.toUpperCase();
						break;
					case "thongso".toLowerCase():
						this.thongso.text = data;
						break;
					case "giatriThongso1".toLowerCase():
						this.giatriThongso1.text = data.toUpperCase();
						break;
					case "giatriThongso2".toLowerCase():
						this.giatriThongso2.text = data.toUpperCase();
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
			bmp.width=50;
			bmp.height=50;
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
			bmp.width=50;
			bmp.height=50;
			this.icon2.addChild(bmp);
		}
	}
	
}
