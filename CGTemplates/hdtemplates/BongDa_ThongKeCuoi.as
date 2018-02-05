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
		
	public class BongDa_ThongKeCuoi extends CasparTemplate{
		
		private var txtGroup:MovieClip = new MovieClip();
		public var icon1:UILoader = null;
		public var icon2:UILoader = null;
		private var request:URLRequest = null;
					
		public var title1:TextField = new TextField();
		public var title2:TextField = new TextField();
		public var title3:TextField = new TextField();
		public var title4:TextField = new TextField();
		public var title5:TextField = new TextField();
		public var title6:TextField = new TextField();
		public var title7:TextField = new TextField();
		public var title8:TextField = new TextField();
		public var title9:TextField = new TextField();
		public var title10:TextField = new TextField();
		public var title11:TextField = new TextField();
		public var title12:TextField = new TextField();
		public var title13:TextField = new TextField();
		public var title14:TextField = new TextField();
		public var title15:TextField = new TextField();
		public var title16:TextField = new TextField();	
		public var title17:TextField = new TextField();
		public var title18:TextField = new TextField();
		public var title19:TextField = new TextField();
		public var title20:TextField = new TextField();	
						
		public function BongDa_ThongKeCuoi() {
			// constructor code
			super();							
			this.txtGroup.addChild(title1);	
			this.txtGroup.addChild(title2);
			this.txtGroup.addChild(title3);
			this.txtGroup.addChild(title4);	
			this.txtGroup.addChild(title5);
			this.txtGroup.addChild(title6);
			this.txtGroup.addChild(title7);	
			this.txtGroup.addChild(title8);
			this.txtGroup.addChild(title9);
			this.txtGroup.addChild(title10);	
			this.txtGroup.addChild(title11);
			this.txtGroup.addChild(title12);
			this.txtGroup.addChild(title13);	
			this.txtGroup.addChild(title14);			
			this.txtGroup.addChild(title15);
			this.txtGroup.addChild(title16);
			this.txtGroup.addChild(title17);	
			this.txtGroup.addChild(title18);			
			this.txtGroup.addChild(title19);
			this.txtGroup.addChild(title20);
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
			xmlStr +=Add(xmlStr, "title1", title1);
			xmlStr +=Add(xmlStr, "title2", title2);
			xmlStr +=Add(xmlStr, "title3", title3);
			xmlStr +=Add(xmlStr, "title4", title4);
			xmlStr +=Add(xmlStr, "title5", title5);
			xmlStr +=Add(xmlStr, "title6", title6);	
			xmlStr +=Add(xmlStr, "title7", title7);
			xmlStr +=Add(xmlStr, "title8", title8);
			xmlStr +=Add(xmlStr, "title9", title9);
			xmlStr +=Add(xmlStr, "title10", title10);
			xmlStr +=Add(xmlStr, "title11", title11);
			xmlStr +=Add(xmlStr, "title12", title12);	
			xmlStr +=Add(xmlStr, "title13", title13);
			xmlStr +=Add(xmlStr, "title14", title14);
			xmlStr +=Add(xmlStr, "title15", title15);
			xmlStr +=Add(xmlStr, "title16", title16);	
			xmlStr +=Add(xmlStr, "title17", title17);
			xmlStr +=Add(xmlStr, "title18", title18);
			xmlStr +=Add(xmlStr, "title19", title19);
			xmlStr +=Add(xmlStr, "title20", title20);
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
					case "title1".toLowerCase():
						this.title1.text = data.toUpperCase();
						break;
					case "title2".toLowerCase():
						this.title2.text = data.toUpperCase();
						break;
					case "title3".toLowerCase():
						this.title3.text = data.toUpperCase();
						break;
					case "title4".toLowerCase():
						this.title4.text = data.toUpperCase();
						break;
					case "title5".toLowerCase():
						this.title5.text = data.toUpperCase();
						break;
					case "title6".toLowerCase():
						this.title6.text = data.toUpperCase();
						break;	
					case "title7".toLowerCase():
						this.title7.text = data.toUpperCase();
						break;
					case "title8".toLowerCase():
						this.title8.text = data.toUpperCase();
						break;
					case "title9".toLowerCase():
						this.title9.text = data.toUpperCase();
						break;
					case "title10".toLowerCase():
						this.title10.text = data.toUpperCase();
						break;					
					case "title11".toLowerCase():
						this.title11.text = data.toUpperCase();
						break;
					case "title12".toLowerCase():
						this.title12.text = data.toUpperCase();
						break;
					case "title13".toLowerCase():
						this.title13.text = data.toUpperCase();
						break;
					case "title14".toLowerCase():
						this.title14.text = data.toUpperCase();
						break;
					case "title15".toLowerCase():
						this.title15.text = data.toUpperCase();
						break;
					case "title16".toLowerCase():
						this.title16.text = data.toUpperCase();
						break;	
					case "title17".toLowerCase():
						this.title17.text = data.toUpperCase();
						break;
					case "title18".toLowerCase():
						this.title18.text = data.toUpperCase();
						break;
					case "title19".toLowerCase():
						this.title19.text = data.toUpperCase();
						break;
					case "title20".toLowerCase():
						this.title20.text = data.toUpperCase();
						break;	
					case "icon1".toLowerCase():						
						request = new URLRequest(data);
						this.icon1.load(request);
						break;
					case "icon2".toLowerCase():						
						request = new URLRequest(data);
						this.icon2.load(request);
						break;
				}
			}
		}
		public override function Play():void{
			gotoAndPlay('start');
		}
		public override function Stop():void{
			//this.stop();
		}
	}
	
}
