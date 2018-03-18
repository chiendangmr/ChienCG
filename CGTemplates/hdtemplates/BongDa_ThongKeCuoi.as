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
		
	public class BongDa_ThongKeCuoi extends CasparTemplate{
		
		private var txtGroup:MovieClip = new MovieClip();
					
		public var hiepdau:TextField = new TextField();
		public var tyso:TextField = new TextField();
		public var dutdiemChu:TextField = new TextField();
		public var dutdiemKhach:TextField = new TextField();
		public var trungdichChu:TextField = new TextField();
		public var trungdichKhach:TextField = new TextField();
		public var phamloiChu:TextField = new TextField();
		public var phamloiKhach:TextField = new TextField();
		public var thevangChu:TextField = new TextField();
		public var thevangKhach:TextField = new TextField();
		public var thedoChu:TextField = new TextField();
		public var thedoKhach:TextField = new TextField();
		public var vietviChu:TextField = new TextField();
		public var vietviKhach:TextField = new TextField();
		public var phatgocChu:TextField = new TextField();
		public var phatgocKhach:TextField = new TextField();	
		public var kiemsoatbongChu:TextField = new TextField();
		public var kiemsoatbongKhach:TextField = new TextField();
		public var doiChu:TextField = new TextField();
		public var doiKhach:TextField = new TextField();	
						
		public function BongDa_ThongKeCuoi() {
			// constructor code
			super();							
			this.txtGroup.addChild(hiepdau);	
			this.txtGroup.addChild(tyso);
			this.txtGroup.addChild(dutdiemChu);
			this.txtGroup.addChild(dutdiemKhach);	
			this.txtGroup.addChild(trungdichChu);
			this.txtGroup.addChild(trungdichKhach);
			this.txtGroup.addChild(phamloiChu);	
			this.txtGroup.addChild(phamloiKhach);
			this.txtGroup.addChild(thevangChu);
			this.txtGroup.addChild(thevangKhach);	
			this.txtGroup.addChild(thedoChu);
			this.txtGroup.addChild(thedoKhach);
			this.txtGroup.addChild(vietviChu);	
			this.txtGroup.addChild(vietviKhach);			
			this.txtGroup.addChild(phatgocChu);
			this.txtGroup.addChild(phatgocKhach);
			this.txtGroup.addChild(kiemsoatbongChu);	
			this.txtGroup.addChild(kiemsoatbongKhach);			
			this.txtGroup.addChild(doiChu);
			this.txtGroup.addChild(doiKhach);
			
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
			xmlStr +=Add(xmlStr, "tyso", tyso);
			xmlStr +=Add(xmlStr, "dutdiemChu", dutdiemChu);
			xmlStr +=Add(xmlStr, "dutdiemKhach", dutdiemKhach);
			xmlStr +=Add(xmlStr, "trungdichChu", trungdichChu);
			xmlStr +=Add(xmlStr, "trungdichKhach", trungdichKhach);	
			xmlStr +=Add(xmlStr, "phamloiChu", phamloiChu);
			xmlStr +=Add(xmlStr, "phamloiKhach", phamloiKhach);
			xmlStr +=Add(xmlStr, "thevangChu", thevangChu);
			xmlStr +=Add(xmlStr, "thevangKhach", thevangKhach);
			xmlStr +=Add(xmlStr, "thedoChu", thedoChu);
			xmlStr +=Add(xmlStr, "thedoKhach", thedoKhach);	
			xmlStr +=Add(xmlStr, "vietviChu", vietviChu);
			xmlStr +=Add(xmlStr, "vietviKhach", vietviKhach);
			xmlStr +=Add(xmlStr, "phatgocChu", phatgocChu);
			xmlStr +=Add(xmlStr, "phatgocKhach", phatgocKhach);	
			xmlStr +=Add(xmlStr, "kiemsoatbongChu", kiemsoatbongChu);
			xmlStr +=Add(xmlStr, "kiemsoatbongKhach", kiemsoatbongKhach);
			xmlStr +=Add(xmlStr, "doiChu", doiChu);
			xmlStr +=Add(xmlStr, "doiKhach", doiKhach);
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
					case "tyso".toLowerCase():
						this.tyso.text = data.toUpperCase();
						break;
					case "dutdiemChu".toLowerCase():
						this.dutdiemChu.text = data.toUpperCase();
						break;
					case "dutdiemKhach".toLowerCase():
						this.dutdiemKhach.text = data.toUpperCase();
						break;
					case "trungdichChu".toLowerCase():
						this.trungdichChu.text = data.toUpperCase();
						break;
					case "trungdichKhach".toLowerCase():
						this.trungdichKhach.text = data.toUpperCase();
						break;	
					case "phamloiChu".toLowerCase():
						this.phamloiChu.text = data.toUpperCase();
						break;
					case "phamloiKhach".toLowerCase():
						this.phamloiKhach.text = data.toUpperCase();
						break;
					case "thevangChu".toLowerCase():
						this.thevangChu.text = data.toUpperCase();
						break;
					case "thevangKhach".toLowerCase():
						this.thevangKhach.text = data.toUpperCase();
						break;					
					case "thedoChu".toLowerCase():
						this.thedoChu.text = data.toUpperCase();
						break;
					case "thedoKhach".toLowerCase():
						this.thedoKhach.text = data.toUpperCase();
						break;
					case "vietviChu".toLowerCase():
						this.vietviChu.text = data.toUpperCase();
						break;
					case "vietviKhach".toLowerCase():
						this.vietviKhach.text = data.toUpperCase();
						break;
					case "phatgocChu".toLowerCase():
						this.phatgocChu.text = data.toUpperCase();
						break;
					case "phatgocKhach".toLowerCase():
						this.phatgocKhach.text = data.toUpperCase();
						break;	
					case "kiemsoatbongChu".toLowerCase():
						this.kiemsoatbongChu.text = data.toUpperCase();
						break;
					case "kiemsoatbongKhach".toLowerCase():
						this.kiemsoatbongKhach.text = data.toUpperCase();
						break;
					case "doiChu".toLowerCase():
						this.doiChu.text = data.toUpperCase();
						break;
					case "doiKhach".toLowerCase():
						this.doiKhach.text = data.toUpperCase();
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
