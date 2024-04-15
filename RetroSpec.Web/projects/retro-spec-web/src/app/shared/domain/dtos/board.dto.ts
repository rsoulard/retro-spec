import { ColumnDto } from "./column.dto";

export interface BoardDto {
  id: string,
  name: string,
  columns: ReadonlyArray<ColumnDto>
}
