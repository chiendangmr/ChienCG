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
		
	public class DavisCup_TySoLon extends CasparTemplate{
		
		private var txtGroup:MovieClip = new MovieClip();
		public var icon1:MovieClip;
		public var icon2:MovieClip;
		
		public var team1:TextField = new TextField();
		public var team2:TextField = new TextField();
		public var set1point1:TextField = new TextField();
		public var set2point1:TextField = new TextField();
		public var set3point1:TextField = new TextField();
		public var set4point1:TextField = new TextField();
		public var set5point1:TextField = new TextField();
		public var set5point2:TextField = new TextField();
		public var set4point2:TextField = new TextField();
		public var set3point2:TextField = new TextField();
		public var set2point2:TextField = new TextField();
		public var set1point2:TextField = new TextField();
		public var set1time:TextField = new TextField();
		public var set2time:TextField = new TextField();
		public var set3time:TextField = new TextField();
		public var set4time:TextField = new TextField();	
		public var set5time:TextField = new TextField();		
						
		public function DavisCup_TySoLon() {
			// constructor code
			super();							
			this.txtGroup.addChild(team1);	
			this.txtGroup.addChild(team2);
			this.txtGroup.addChild(set1point1);
			this.txtGroup.addChild(set2point1);	
			this.txtGroup.addChild(set3point1);
			this.txtGroup.addChild(set4point1);
			this.txtGroup.addChild(set5point1);	
			this.txtGroup.addChild(set5point2);
			this.txtGroup.addChild(set4point2);
			this.txtGroup.addChild(set3point2);	
			this.txtGroup.addChild(set2point2);
			this.txtGroup.addChild(set1point2);
			this.txtGroup.addChild(set1time);	
			this.txtGroup.addChild(set2time);			
			this.txtGroup.addChild(set3time);
			this.txtGroup.addChild(set4time);
			this.txtGroup.addChild(set5time);			
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
			xmlStr +=Add(xmlStr, "team1", team1);
			xmlStr +=Add(xmlStr, "team2", team2);
			xmlStr +=Add(xmlStr, "set1point1", set1point1);
			xmlStr +=Add(xmlStr, "set2point1", set2point1);
			xmlStr +=Add(xmlStr, "set3point1", set3point1);
			xmlStr +=Add(xmlStr, "set4point1", set4point1);	
			xmlStr +=Add(xmlStr, "set5point1", set5point1);
			xmlStr +=Add(xmlStr, "set5point2", set5point2);
			xmlStr +=Add(xmlStr, "set4point2", set4point2);
			xmlStr +=Add(xmlStr, "set3point2", set3point2);
			xmlStr +=Add(xmlStr, "set2point2", set2point2);
			xmlStr +=Add(xmlStr, "set1point2", set1point2);	
			xmlStr +=Add(xmlStr, "set1time", set1time);
			xmlStr +=Add(xmlStr, "set2time", set2time);
			xmlStr +=Add(xmlStr, "set3time", set3time);
			xmlStr +=Add(xmlStr, "set4time", set4time);	
			xmlStr +=Add(xmlStr, "set5time", set5time);			
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
					case "team1".toLowerCase():
						this.team1.text = data.toUpperCase();
						break;
					case "team2".toLowerCase():
						this.team2.text = data.toUpperCase();
						break;
					case "set1point1".toLowerCase():
						this.set1point1.text = data.toUpperCase();
						break;
					case "set2point1".toLowerCase():
						this.set2point1.text = data.toUpperCase();
						break;
					case "set3point1".toLowerCase():
						this.set3point1.text = data.toUpperCase();
						break;
					case "set4point1".toLowerCase():
						this.set4point1.text = data.toUpperCase();
						break;	
					case "set5point1".toLowerCase():
						this.set5point1.text = data.toUpperCase();
						break;
					case "set5point2".toLowerCase():
						this.set5point2.text = data.toUpperCase();
						break;
					case "set4point2".toLowerCase():
						this.set4point2.text = data.toUpperCase();
						break;
					case "set3point2".toLowerCase():
						this.set3point2.text = data.toUpperCase();
						break;					
					case "set2point2".toLowerCase():
						this.set2point2.text = data.toUpperCase();
						break;
					case "set1point2".toLowerCase():
						this.set1point2.text = data.toUpperCase();
						break;
					case "set1time".toLowerCase():
						this.set1time.text = data.toUpperCase();
						break;
					case "set2time".toLowerCase():
						this.set2time.text = data.toUpperCase();
						break;
					case "set3time".toLowerCase():
						this.set3time.text = data.toUpperCase();
						break;
					case "set4time".toLowerCase():
						this.set4time.text = data.toUpperCase();
						break;	
					case "set5time".toLowerCase():
						this.set5time.text = data.toUpperCase();
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
