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
		
	public class BongDa_TySoChinh extends CasparTemplate{
		
		private var txtGroup:MovieClip = new MovieClip();
		public var icon1:UILoader = null;
		public var icon2:UILoader = null;
		private var request:URLRequest = null;
					
		public var hiepdau:TextField = new TextField();
		public var doiChu:TextField = new TextField();
		public var doiKhach:TextField = new TextField();
		public var tyso:TextField = new TextField();
		public var ghibanChu1:TextField = new TextField();
		public var ghibanChu2:TextField = new TextField();
		public var ghibanChu3:TextField = new TextField();
		public var ghibanChu4:TextField = new TextField();
		public var ghibanChu5:TextField = new TextField();
		public var ghibanChu6:TextField = new TextField();
		public var ghibanChu7:TextField = new TextField();
		public var ghibanChu8:TextField = new TextField();
		public var ghibanChu9:TextField = new TextField();
		public var ghibanChu10:TextField = new TextField();
		public var ghibanKhach1:TextField = new TextField();
		public var ghibanKhach2:TextField = new TextField();
		public var ghibanKhach3:TextField = new TextField();
		public var ghibanKhach4:TextField = new TextField();
		public var ghibanKhach5:TextField = new TextField();
		public var ghibanKhach6:TextField = new TextField();
		public var ghibanKhach7:TextField = new TextField();
		public var ghibanKhach8:TextField = new TextField();
		public var ghibanKhach9:TextField = new TextField();
		public var ghibanKhach10:TextField = new TextField();
						
		public function BongDa_TySoChinh() {
			// constructor code
			super();							
			this.txtGroup.addChild(hiepdau);	
			this.txtGroup.addChild(doiChu);
			this.txtGroup.addChild(doiKhach);
			this.txtGroup.addChild(tyso);	
			this.txtGroup.addChild(ghibanChu1);
			this.txtGroup.addChild(ghibanChu2);
			this.txtGroup.addChild(ghibanChu3);	
			this.txtGroup.addChild(ghibanChu4);
			this.txtGroup.addChild(ghibanChu5);
			this.txtGroup.addChild(ghibanChu6);	
			this.txtGroup.addChild(ghibanChu7);	
			this.txtGroup.addChild(ghibanChu8);
			this.txtGroup.addChild(ghibanChu9);
			this.txtGroup.addChild(ghibanChu10);	
			this.txtGroup.addChild(ghibanKhach1);
			this.txtGroup.addChild(ghibanKhach2);
			this.txtGroup.addChild(ghibanKhach3);	
			this.txtGroup.addChild(ghibanKhach4);			
			this.txtGroup.addChild(ghibanKhach5);
			this.txtGroup.addChild(ghibanKhach6);
			this.txtGroup.addChild(ghibanKhach7);	
			this.txtGroup.addChild(ghibanKhach8);			
			this.txtGroup.addChild(ghibanKhach9);
			this.txtGroup.addChild(ghibanKhach10);
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
			xmlStr +=Add(xmlStr, "hiepdau", hiepdau);
			xmlStr +=Add(xmlStr, "doiChu", doiChu);
			xmlStr +=Add(xmlStr, "doiKhach", doiKhach);
			xmlStr +=Add(xmlStr, "tyso", tyso);
			xmlStr +=Add(xmlStr, "ghibanChu1", ghibanChu1);
			xmlStr +=Add(xmlStr, "ghibanChu2", ghibanChu2);	
			xmlStr +=Add(xmlStr, "ghibanChu3", ghibanChu3);
			xmlStr +=Add(xmlStr, "ghibanChu4", ghibanChu4);
			xmlStr +=Add(xmlStr, "ghibanChu5", ghibanChu5);
			xmlStr +=Add(xmlStr, "ghibanChu6", ghibanChu6);
			xmlStr +=Add(xmlStr, "ghibanChu7", ghibanChu7);
			xmlStr +=Add(xmlStr, "ghibanChu8", ghibanChu8);
			xmlStr +=Add(xmlStr, "ghibanChu9", ghibanChu9);
			xmlStr +=Add(xmlStr, "ghibanChu10", ghibanChu10);
			xmlStr +=Add(xmlStr, "ghibanKhach1", ghibanKhach1);
			xmlStr +=Add(xmlStr, "ghibanKhach2", ghibanKhach2);	
			xmlStr +=Add(xmlStr, "ghibanKhach3", ghibanKhach3);
			xmlStr +=Add(xmlStr, "ghibanKhach4", ghibanKhach4);
			xmlStr +=Add(xmlStr, "ghibanKhach5", ghibanKhach5);
			xmlStr +=Add(xmlStr, "ghibanKhach6", ghibanKhach6);	
			xmlStr +=Add(xmlStr, "ghibanKhach7", ghibanKhach7);
			xmlStr +=Add(xmlStr, "ghibanKhach8", ghibanKhach8);
			xmlStr +=Add(xmlStr, "ghibanKhach9", ghibanKhach9);
			xmlStr +=Add(xmlStr, "ghibanKhach10", ghibanKhach10);
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
					case "hiepdau".toLowerCase():
						this.hiepdau.text = data.toUpperCase();
						break;
					case "doiChu".toLowerCase():
						this.doiChu.text = data.toUpperCase();
						break;
					case "doiKhach".toLowerCase():
						this.doiKhach.text = data.toUpperCase();
						break;
					case "tyso".toLowerCase():
						this.tyso.text = data.toUpperCase();
						break;
					case "ghibanChu1".toLowerCase():
						this.ghibanChu1.text = data.toUpperCase();
						break;
					case "ghibanChu2".toLowerCase():
						this.ghibanChu2.text = data.toUpperCase();
						break;	
					case "ghibanChu3".toLowerCase():
						this.ghibanChu3.text = data.toUpperCase();
						break;
					case "ghibanChu4".toLowerCase():
						this.ghibanChu4.text = data.toUpperCase();
						break;
					case "ghibanChu5".toLowerCase():
						this.ghibanChu5.text = data.toUpperCase();
						break;
					case "ghibanChu6".toLowerCase():
						this.ghibanChu6.text = data.toUpperCase();
						break;		
					case "ghibanChu7".toLowerCase():
						this.ghibanChu7.text = data.toUpperCase();
						break;
					case "ghibanChu8".toLowerCase():
						this.ghibanChu8.text = data.toUpperCase();
						break;
					case "ghibanChu9".toLowerCase():
						this.ghibanChu9.text = data.toUpperCase();
						break;
					case "ghibanChu10".toLowerCase():
						this.ghibanChu10.text = data.toUpperCase();
						break;			
					case "ghibanKhach1".toLowerCase():
						this.ghibanKhach1.text = data.toUpperCase();
						break;
					case "ghibanKhach2".toLowerCase():
						this.ghibanKhach2.text = data.toUpperCase();
						break;
					case "ghibanKhach3".toLowerCase():
						this.ghibanKhach3.text = data.toUpperCase();
						break;
					case "ghibanKhach4".toLowerCase():
						this.ghibanKhach4.text = data.toUpperCase();
						break;
					case "ghibanKhach5".toLowerCase():
						this.ghibanKhach5.text = data.toUpperCase();
						break;
					case "ghibanKhach6".toLowerCase():
						this.ghibanKhach6.text = data.toUpperCase();
						break;	
					case "ghibanKhach7".toLowerCase():
						this.ghibanKhach7.text = data.toUpperCase();
						break;
					case "ghibanKhach8".toLowerCase():
						this.ghibanKhach8.text = data.toUpperCase();
						break;
					case "ghibanKhach9".toLowerCase():
						this.ghibanKhach9.text = data.toUpperCase();
						break;
					case "ghibanKhach10".toLowerCase():
						this.ghibanKhach10.text = data.toUpperCase();
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
			gotoAndPlay('stop');
		}
	}
	
}
