import * as i0 from '@angular/core';
import { Component, input } from '@angular/core';

class CardComponent {
    static { this.ɵfac = i0.ɵɵngDeclareFactory({ minVersion: "12.0.0", version: "17.3.2", ngImport: i0, type: CardComponent, deps: [], target: i0.ɵɵFactoryTarget.Component }); }
    static { this.ɵcmp = i0.ɵɵngDeclareComponent({ minVersion: "14.0.0", version: "17.3.2", type: CardComponent, isStandalone: true, selector: "retro-card", ngImport: i0, template: "<div class=\"rounded-lg border border-slate-300 transition ease-in-out delay-75 shadow-md hover:shadow-xl w-64 h-72 p-4\">\r\n  <ng-content></ng-content>\r\n</div>\r\n", styles: [""] }); }
}
i0.ɵɵngDeclareClassMetadata({ minVersion: "12.0.0", version: "17.3.2", ngImport: i0, type: CardComponent, decorators: [{
            type: Component,
            args: [{ selector: 'retro-card', standalone: true, imports: [], template: "<div class=\"rounded-lg border border-slate-300 transition ease-in-out delay-75 shadow-md hover:shadow-xl w-64 h-72 p-4\">\r\n  <ng-content></ng-content>\r\n</div>\r\n" }]
        }] });

class ColumnComponent {
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

class ButtonComponent {
    constructor() {
        this.title = input();
        this.onClick = input(() => { });
    }
    static { this.ɵfac = i0.ɵɵngDeclareFactory({ minVersion: "12.0.0", version: "17.3.2", ngImport: i0, type: ButtonComponent, deps: [], target: i0.ɵɵFactoryTarget.Component }); }
    static { this.ɵcmp = i0.ɵɵngDeclareComponent({ minVersion: "17.1.0", version: "17.3.2", type: ButtonComponent, isStandalone: true, selector: "retro-button", inputs: { title: { classPropertyName: "title", publicName: "title", isSignal: true, isRequired: false, transformFunction: null }, onClick: { classPropertyName: "onClick", publicName: "onClick", isSignal: true, isRequired: false, transformFunction: null } }, ngImport: i0, template: "<button class=\"text-md leading-none rounded-lg text-white font-semibold bg-violet-600 hover:bg-violet-700 py-2 px-5\" (click)=\"onClick()($event)\">{{title()}}</button>\r\n", styles: [""] }); }
}
i0.ɵɵngDeclareClassMetadata({ minVersion: "12.0.0", version: "17.3.2", ngImport: i0, type: ButtonComponent, decorators: [{
            type: Component,
            args: [{ selector: 'retro-button', standalone: true, imports: [], template: "<button class=\"text-md leading-none rounded-lg text-white font-semibold bg-violet-600 hover:bg-violet-700 py-2 px-5\" (click)=\"onClick()($event)\">{{title()}}</button>\r\n" }]
        }] });

/*
 * Public API Surface of retro-spec-components
 */

/**
 * Generated bundle index. Do not edit.
 */

export { ButtonComponent, CardComponent, ColumnComponent };
//# sourceMappingURL=retro-spec-components.mjs.map
