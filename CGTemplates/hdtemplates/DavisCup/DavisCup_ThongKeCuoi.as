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
		
	public class DavisCup_ThongKeCuoi extends CasparTemplate{
		
		public var viewGroup:MovieClip = new MovieClip();
		public var icon1:MovieClip;
		public var icon2:MovieClip;
		
		public var giaidau:TextField = new TextField();
		public var vongdau:TextField = new TextField();
		public var setSummary:TextField = new TextField();
		public var team1:TextField = new TextField();
		public var team2:TextField = new TextField();
		public var setTimeFull:TextField = new TextField();
		public var servesIn:TextField = new TextField();
		public var servesWon:TextField = new TextField();
		public var servesIn1:TextField = new TextField();
		public var servesIn2:TextField = new TextField();
		public var servesWon1:TextField = new TextField();
		public var servesWon2:TextField = new TextField();
		public var aces1:TextField = new TextField();
		public var aces2:TextField = new TextField();
		public var doubleF1:TextField = new TextField();
		public var doubleF2:TextField = new TextField();
		public var forehandW1:TextField = new TextField();
		public var forehandW2:TextField = new TextField();	
		public var backhandW1:TextField = new TextField();
		public var backhandW2:TextField = new TextField();
		public var pointWinAtNet1:TextField = new TextField();
		public var pointWinAtNet2:TextField = new TextField();	
		public var breakpointW1:TextField = new TextField();
		public var breakpointW2:TextField = new TextField();	
		public var unforcedE1:TextField = new TextField();
		public var unforcedE2:TextField = new TextField();	
						
		public function DavisCup_ThongKeCuoi() {
			// constructor code
			super();
			
			this.viewGroup.addChild(giaidau);
			this.viewGroup.addChild(vongdau);
			this.viewGroup.addChild(setSummary);
			this.viewGroup.addChild(team1);
			this.viewGroup.addChild(team2);
			this.viewGroup.addChild(setTimeFull);
			this.viewGroup.addChild(servesIn);
			this.viewGroup.addChild(servesWon);
			this.viewGroup.addChild(servesIn1);
			this.viewGroup.addChild(servesIn2);
			this.viewGroup.addChild(servesWon1);
			this.viewGroup.addChild(servesWon2);
			this.viewGroup.addChild(aces1);
			this.viewGroup.addChild(aces2);
			this.viewGroup.addChild(doubleF1);
			this.viewGroup.addChild(doubleF2);
			this.viewGroup.addChild(forehandW1);
			this.viewGroup.addChild(forehandW2);
			this.viewGroup.addChild(backhandW1);
			this.viewGroup.addChild(backhandW2);
			this.viewGroup.addChild(pointWinAtNet1);
			this.viewGroup.addChild(pointWinAtNet2);
			this.viewGroup.addChild(breakpointW1);
			this.viewGroup.addChild(breakpointW2);
			this.viewGroup.addChild(unforcedE1);
			this.viewGroup.addChild(unforcedE2);
			this.viewGroup.addChild(icon1);
			this.viewGroup.addChild(icon2);
			this.addChild(viewGroup);
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
			xmlStr +=Add(xmlStr, "setSummary", setSummary);
			xmlStr +=Add(xmlStr, "team1", team1);
			xmlStr +=Add(xmlStr, "team2", team2);
			xmlStr +=Add(xmlStr, "setTimeFull", setTimeFull);	
			xmlStr +=Add(xmlStr, "servesIn1", servesIn1);
			xmlStr +=Add(xmlStr, "servesIn2", servesIn2);
			xmlStr +=Add(xmlStr, "servesWon1", servesWon1);
			xmlStr +=Add(xmlStr, "servesWon2", servesWon2);
			xmlStr +=Add(xmlStr, "aces1", aces1);
			xmlStr +=Add(xmlStr, "aces2", aces2);	
			xmlStr +=Add(xmlStr, "doubleF1", doubleF1);
			xmlStr +=Add(xmlStr, "doubleF2", doubleF2);
			xmlStr +=Add(xmlStr, "forehandW1", forehandW1);
			xmlStr +=Add(xmlStr, "forehandW2", forehandW2);	
			xmlStr +=Add(xmlStr, "backhandW1", backhandW1);
			xmlStr +=Add(xmlStr, "backhandW2", backhandW2);
			xmlStr +=Add(xmlStr, "pointWinAtNet1", pointWinAtNet1);
			xmlStr +=Add(xmlStr, "pointWinAtNet2", pointWinAtNet2);
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
					case "setSummary".toLowerCase():
						this.setSummary.text = data.toUpperCase();
						break;
					case "team1".toLowerCase():
						this.team1.text = data.toUpperCase();
						break;
					case "team2".toLowerCase():
						this.team2.text = data.toUpperCase();
						break;
					case "setTimeFull".toLowerCase():
						this.setTimeFull.text = data.toUpperCase();
						break;
					case "servesIn".toLowerCase():
						this.servesIn.text = data;
						break;
					case "servesWon".toLowerCase():
						this.servesWon.text = data;
						break;
					case "servesIn1".toLowerCase():
						this.servesIn1.text = data.toUpperCase();
						break;
					case "servesIn2".toLowerCase():
						this.servesIn2.text = data.toUpperCase();
						break;
					case "servesWon1".toLowerCase():
						this.servesWon1.text = data.toUpperCase();
						break;
					case "servesWon2".toLowerCase():
						this.servesWon2.text = data.toUpperCase();
						break;					
					case "aces1".toLowerCase():
						this.aces1.text = data.toUpperCase();
						break;
					case "aces2".toLowerCase():
						this.aces2.text = data.toUpperCase();
						break;
					case "doubleF1".toLowerCase():
						this.doubleF1.text = data.toUpperCase();
						break;
					case "doubleF2".toLowerCase():
						this.doubleF2.text = data.toUpperCase();
						break;
					case "forehandW1".toLowerCase():
						this.forehandW1.text = data.toUpperCase();
						break;
					case "forehandW2".toLowerCase():
						this.forehandW2.text = data.toUpperCase();
						break;	
					case "backhandW1".toLowerCase():
						this.backhandW1.text = data.toUpperCase();
						break;
					case "backhandW2".toLowerCase():
						this.backhandW2.text = data.toUpperCase();
						break;
					case "pointWinAtNet1".toLowerCase():
						this.pointWinAtNet1.text = data.toUpperCase();
						break;
					case "pointWinAtNet2".toLowerCase():
						this.pointWinAtNet2.text = data.toUpperCase();
						break;	
					case "breakpointW1".toLowerCase():
						this.breakpointW1.text = data.toUpperCase();
						break;
					case "breakpointW2".toLowerCase():
						this.breakpointW2.text = data.toUpperCase();
						break;	
					case "unforcedE1".toLowerCase():
						this.unforcedE1.text = data.toUpperCase();
						break;
					case "unforcedE2".toLowerCase():
						this.unforcedE2.text = data.toUpperCase();
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
			bmp.width=130;
			bmp.height=130;
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
			bmp.width=130;
			bmp.height=130;
			this.icon2.addChild(bmp);
		}
	}
	
}
