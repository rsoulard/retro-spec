import * as i0 from '@angular/core';
import { Component } from '@angular/core';

class CardComponent {
    static { this.ɵfac = i0.ɵɵngDeclareFactory({ minVersion: "12.0.0", version: "17.3.2", ngImport: i0, type: CardComponent, deps: [], target: i0.ɵɵFactoryTarget.Component }); }
    static { this.ɵcmp = i0.ɵɵngDeclareComponent({ minVersion: "14.0.0", version: "17.3.2", type: CardComponent, isStandalone: true, selector: "retro-card", ngImport: i0, template: "<div class=\"rounded-lg border border-slate-300 transition ease-in-out delay-75 shadow-md hover:shadow-xl w-64 h-72 p-4\">\r\n  <ng-content></ng-content>\r\n</div>\r\n", styles: [""] }); }
}
i0.ɵɵngDeclareClassMetadata({ minVersion: "12.0.0", version: "17.3.2", ngImport: i0, type: CardComponent, decorators: [{
            type: Component,
            args: [{ selector: 'retro-card', standalone: true, imports: [], template: "<div class=\"rounded-lg border border-slate-300 transition ease-in-out delay-75 shadow-md hover:shadow-xl w-64 h-72 p-4\">\r\n  <ng-content></ng-content>\r\n</div>\r\n" }]
        }] });

class ColumnComponent {
    static { this.ɵfac = i0.ɵɵngDeclareFactory({ minVersion: "12.0.0", version: "17.3.2", ngImport: i0, type: ColumnComponent, deps: [], target: i0.ɵɵFactoryTarget.Component }); }
    static { this.ɵcmp = i0.ɵɵngDeclareComponent({ minVersion: "14.0.0", version: "17.3.2", type: ColumnComponent, isStandalone: true, selector: "retro-column", ngImport: i0, template: "<div class=\"rounded-lg bg-slate-300 h-full max-w-80\">\r\n  <p>Hello?</p>\r\n</div>\r\n", styles: [""] }); }
}
i0.ɵɵngDeclareClassMetadata({ minVersion: "12.0.0", version: "17.3.2", ngImport: i0, type: ColumnComponent, decorators: [{
            type: Component,
            args: [{ selector: 'retro-column', standalone: true, imports: [], template: "<div class=\"rounded-lg bg-slate-300 h-full max-w-80\">\r\n  <p>Hello?</p>\r\n</div>\r\n" }]
        }] });

/*
 * Public API Surface of retro-spec-components
 */

/**
 * Generated bundle index. Do not edit.
 */

export { CardComponent, ColumnComponent };
//# sourceMappingURL=retro-spec-components.mjs.map
