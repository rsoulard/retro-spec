export interface PaginatedCollection<TItem> {
  items: ReadonlyArray<TItem>,
  pageSize: number,
  pageIndex: number,
  hasPreviousPage: boolean,
  hasNextPage: boolean,
  totalPages: number
}
