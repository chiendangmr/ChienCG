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
	import fl.containers.UILoader;
	import flash.net.URLRequest;
	import flash.sampler.Sample;
	import flash.globalization.NumberFormatter;
	import flash.globalization.LocaleID;
		
	public class BongDa_ThayNguoi extends CasparTemplate{
		
		private var txtGroup:MovieClip = new MovieClip();		
		
		public var playerout:TextField = new TextField();
		public var playerOutNumber:TextField = new TextField();
		public var playerin:TextField = new TextField();
		public var playerInNumber:TextField = new TextField();
		
		public function BongDa_ThayNguoi() {
			// constructor code
			super();							
			this.txtGroup.addChild(playerout);
			this.txtGroup.addChild(playerOutNumber);
			this.txtGroup.addChild(playerin);
			this.txtGroup.addChild(playerInNumber);
			
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
			xmlStr +=Add(xmlStr, "playerout", playerout);
			xmlStr +=Add(xmlStr, "playerOutNumber", playerOutNumber);
			xmlStr +=Add(xmlStr, "playerin", playerin);
			xmlStr +=Add(xmlStr, "playerInNumber", playerInNumber);
				
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
					case "playerout".toLowerCase():
						this.playerout.text = data.toUpperCase();
						break;
					case "playerOutNumber".toLowerCase():
						this.playerOutNumber.text = data.toUpperCase()+".";
						break;		
					case "playerin".toLowerCase():
						this.playerin.text = data.toUpperCase();
						break;
					case "playerInNumber".toLowerCase():
						this.playerInNumber.text = data.toUpperCase()+".";
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
	}
	
}
