import { Component, input } from '@angular/core';
import * as i0 from "@angular/core";
export class ColumnComponent {
    constructor() {
        this.title = input.required();
    }
    static { this.ɵfac = i0.ɵɵngDeclareFactory({ minVersion: "12.0.0", version: "17.3.2", ngImport: i0, type: ColumnComponent, deps: [], target: i0.ɵɵFactoryTarget.Component }); }
    static { this.ɵcmp = i0.ɵɵngDeclareComponent({ minVersion: "17.1.0", version: "17.3.2", type: ColumnComponent, isStandalone: true, selector: "retro-column", inputs: { title: { classPropertyName: "title", publicName: "title", isSignal: true, isRequired: true, transformFunction: null } }, ngImport: i0, template: "<div class=\"rounded-lg bg-slate-300 h-full max-w-80\">\r\n  <div>\r\n    <h1 class=\"p-3 text-xl font-semibold\">{{title()}}</h1>\r\n  </div>\r\n</div>\r\n", styles: [""] }); }
}
i0.ɵɵngDeclareClassMetadata({ minVersion: "12.0.0", version: "17.3.2", ngImport: i0, type: ColumnComponent, decorators: [{
            type: Component,
            args: [{ selector: 'retro-column', standalone: true, imports: [], template: "<div class=\"rounded-lg bg-slate-300 h-full max-w-80\">\r\n  <div>\r\n    <h1 class=\"p-3 text-xl font-semibold\">{{title()}}</h1>\r\n  </div>\r\n</div>\r\n" }]
        }] });
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJmaWxlIjoiY29sdW1uLmNvbXBvbmVudC5qcyIsInNvdXJjZVJvb3QiOiIiLCJzb3VyY2VzIjpbIi4uLy4uLy4uLy4uLy4uL3Byb2plY3RzL3JldHJvLXNwZWMtY29tcG9uZW50cy9zcmMvbGliL2NvbHVtbi9jb2x1bW4uY29tcG9uZW50LnRzIiwiLi4vLi4vLi4vLi4vLi4vcHJvamVjdHMvcmV0cm8tc3BlYy1jb21wb25lbnRzL3NyYy9saWIvY29sdW1uL2NvbHVtbi5jb21wb25lbnQuaHRtbCJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiQUFBQSxPQUFPLEVBQUUsU0FBUyxFQUFFLEtBQUssRUFBRSxNQUFNLGVBQWUsQ0FBQzs7QUFTakQsTUFBTSxPQUFPLGVBQWU7SUFQNUI7UUFRRSxVQUFLLEdBQUcsS0FBSyxDQUFDLFFBQVEsRUFBVSxDQUFDO0tBQ2xDOzhHQUZZLGVBQWU7a0dBQWYsZUFBZSwyTUNUNUIsOEpBS0E7OzJGRElhLGVBQWU7a0JBUDNCLFNBQVM7K0JBQ0UsY0FBYyxjQUNaLElBQUksV0FDUCxFQUFFIiwic291cmNlc0NvbnRlbnQiOlsiaW1wb3J0IHsgQ29tcG9uZW50LCBpbnB1dCB9IGZyb20gJ0Bhbmd1bGFyL2NvcmUnO1xyXG5cclxuQENvbXBvbmVudCh7XHJcbiAgc2VsZWN0b3I6ICdyZXRyby1jb2x1bW4nLFxyXG4gIHN0YW5kYWxvbmU6IHRydWUsXHJcbiAgaW1wb3J0czogW10sXHJcbiAgdGVtcGxhdGVVcmw6ICcuL2NvbHVtbi5jb21wb25lbnQuaHRtbCcsXHJcbiAgc3R5bGVVcmw6ICcuL2NvbHVtbi5jb21wb25lbnQuY3NzJ1xyXG59KVxyXG5leHBvcnQgY2xhc3MgQ29sdW1uQ29tcG9uZW50IHtcclxuICB0aXRsZSA9IGlucHV0LnJlcXVpcmVkPHN0cmluZz4oKTtcclxufVxyXG4iLCI8ZGl2IGNsYXNzPVwicm91bmRlZC1sZyBiZy1zbGF0ZS0zMDAgaC1mdWxsIG1heC13LTgwXCI+XHJcbiAgPGRpdj5cclxuICAgIDxoMSBjbGFzcz1cInAtMyB0ZXh0LXhsIGZvbnQtc2VtaWJvbGRcIj57e3RpdGxlKCl9fTwvaDE+XHJcbiAgPC9kaXY+XHJcbjwvZGl2PlxyXG4iXX0=