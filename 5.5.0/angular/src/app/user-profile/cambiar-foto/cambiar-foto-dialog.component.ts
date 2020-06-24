import { Component, Injector, OnInit } from '@angular/core';
import { MatDialogRef, MatCheckboxChange } from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {EventosServiceProxy, EventoDto, CreateEventoDto,
   
} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'cambiar-foto-dialog.component.html',
    styles: [
        `
      mat-form-field {
        width: 100%;
      }
      mat-checkbox {
        padding-bottom: 5px;
      }
    `
    ]
})
export class CambiarFotoDialogComponent extends AppComponentBase  {
    saving = false;
      

    constructor(
        injector: Injector,
        private _dialogRef: MatDialogRef<CambiarFotoDialogComponent>
    ) {
        super(injector);
    }

  
    
    save(): void {
        this.saving = true;
        this.close(true);
    }

    close(result: any): void {
        this._dialogRef.close(result);
    }
}
