import { Component,  Injector } from '@angular/core';
import {EventosServiceProxy, EventoDto, AuthenticateResultModel, EventoDtoPagedResultDto } from 'shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {PagedListingComponentBase,PagedRequestDto} from '@shared/paged-listing-component-base';
import { MatDialog } from '@angular/material/dialog';
import { CreateEventoDialogComponent } from './create-evento/create-evento-dialog.component';
//import { EditEventoDialogComponent } from './edit-evento/edit-evento-dialog.component';

class PagedRolesRequestDto extends PagedRequestDto {
    filter: string;
}

@Component({
  //selector: 'app-eventos',
    templateUrl: './eventos.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})


export class EventosComponent extends PagedListingComponentBase<EventoDto> {

    eventos: EventoDto[] = [];
    filterText = '';
    constructor(
        injector: Injector,
        private _eventoService: EventosServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
    }

    list(
        request: PagedRolesRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        request.filter = this.filterText;

        this._eventoService
            .getAll()
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe(result  => {
                this.eventos = result.items;
            });

    //ngOnInit() {
    //    this._eventoService.getAll('', 0, 20)
    //        .subscribe(result =>
    //        this.eventos = result.items);
    }

    delete(evento: EventoDto): void {
        abp.message.confirm(
            this.l('RoleDeleteWarningMessage', evento.nombreEvento),
            undefined,
            (result: boolean) => {
                if (result) {
                    this._eventoService
                        .delete(evento.id)
                        .pipe(
                            finalize(() => {
                                abp.notify.success(this.l('SuccessfullyDeleted'));
                                this.refresh();
                            })
                        )
                        .subscribe(() => { });
                }
            }
        );
    }

    createEvento(): void {
        this.showCreateOrEditEventoDialog();
    }

    editEvento(evento: EventoDto): void {
        this.showCreateOrEditEventoDialog(evento.id);
    }

    showCreateOrEditEventoDialog(id?: number): void {
        /*
        let createOrEditEventoDialog;
        if (id === undefined || id <= 0) {
            createOrEditEventoDialog = this._dialog.open(CreateEventoDialogComponent);
        } else {
            createOrEditEventoDialog = this._dialog.open(EditEventoDialogComponent, {
                data: id
            });
        }

        createOrEditEventoDialog.afterClosed().subscribe(result => {
            if (result) {
                this.refresh();
            }
        });
        */
    }


}