<template>
  <div>
    <h2>公司營收列表</h2>
    <div v-if="isLoading">載入中...</div>
    <div v-else>
      <p>總筆數：{{ totalCount }}</p>
      <div class="table-container">
        <table class="revenue-table">
          <thead>
            <tr>
              <th v-for="header in headers" :key="header">{{ header }}</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="item in pagedData" :key="item.companyId + item.dataYearMonth">
              <td>{{ formatToROCDate(item.reportDate) }}</td>
              <td>{{ item.dataYearMonth }}</td>
              <td>{{ item.companyId }}</td>
              <td>{{ item.companyName }}</td>
              <td>{{ item.industry }}</td>
              <td class="Amount">{{ formatCurrency(item.revenueCurrentMonth) }}</td>
              <td class="Amount">{{ formatCurrency(item.revenueLastMonth) }}</td>
              <td class="Amount">{{ formatCurrency(item.revenueSameMonthLastYear) }}</td>
              <td class="Amount">{{ formatPercent(item.moMChangePercent) }}</td>
              <td class="Amount">{{ formatPercent(item.yoYChangePercent) }}</td>
              <td class="Amount">{{ formatCurrency(item.accRevenueCurrent) }}</td>
              <td class="Amount">{{ formatCurrency(item.accRevenueLastYear) }}</td>
              <td class="Amount">{{ formatPercent(item.accChangePercent) }}</td>
              <td class="note">{{ item.note }}</td>
            </tr>
          </tbody>
        </table>
      </div>
      <!-- 分頁按鈕 -->
      <div class="pagination">
        <button @click="goToFirstPage" :disabled="currentPage === 1">第一頁</button>
          <button @click="prevPage" :disabled="currentPage === 1">上一頁</button>
          <span>第 {{ currentPage }} 頁 / 共 {{ totalPages }} 頁</span>
          <button @click="nextPage" :disabled="currentPage === totalPages">下一頁</button>
          <button @click="goToLastPage" :disabled="currentPage === totalPages">最後一頁</button>
        </div>
    </div>
  </div>
</template>

<script setup>
import { onMounted, ref, computed } from 'vue'

const revenues = ref([])
const isLoading = ref(true)
const currentPage = ref(1)
const pageSize = 15
const totalPages = computed(() => Math.ceil(revenues.value.length / pageSize))
const pagedData = computed(() => {
  const start = (currentPage.value - 1) * pageSize
  return revenues.value.slice(start, start + pageSize)
})

function goToFirstPage() {
  currentPage.value = 1
}
function goToLastPage() {
  currentPage.value = totalPages.value
}
function nextPage() {
  if (currentPage.value < totalPages.value) currentPage.value++
}

function prevPage() {
  if (currentPage.value > 1) currentPage.value--
}
const headers = [
  '報告日期', '資料年月', '公司代號', '公司名稱', '產業別',
  '當月營收', '上月營收', '去年同月營收',
  '月增率 (%)', '年增率 (%)',
  '累計營收', '去年累計營收', '累計增率 (%)',
  '備註'
]

const fetchRevenue = async () => {
  try {
    const res = await fetch('https://localhost:7243/api/MonthlyRevenue') // 替換為你的 API URL
    const data = await res.json()
    revenues.value = data
  } catch (error) {
    console.error('API 錯誤:', error)
  } finally {
    isLoading.value = false
  }
}

onMounted(() => {
  fetchRevenue()
})

const totalCount = computed(() => revenues.value.length)

const formatCurrency = (val) =>
  val != null ? Number(val).toLocaleString('zh-TW', { style: 'currency', currency: 'TWD' }) : '-'

const formatPercent = (val) =>
  val != null ? `${Math.round(val * 100) / 100}%` : '-'

const formatToROCDate = (isoDateString) => {
  if (!isoDateString) return '-'
  const date = new Date(isoDateString)
  const rocYear = date.getFullYear() - 1911
  const month = String(date.getMonth() + 1).padStart(2, '0')
  const day = String(date.getDate()).padStart(2, '0')
  return `${rocYear}-${month}-${day}`
}
</script>

<style scoped>

table {
  width: 100%;
  border-collapse: collapse;
  margin-top: 1rem;
}

th,
td {
  border: 1px solid #ddd;
  padding: 8px;
  text-align: center;
}

th {
  background-color: #f4f4f4;
}

tbody tr:nth-child(even) {
  background-color: #f9f9f9;
}

tbody tr:hover {
  background-color: #f1f1f1;
}

.table-container {
  overflow-x: auto;
  width: 100%;
}

.revenue-table {
  width: max-content;
  /* 讓表格寬度撐開到所有欄位 */
  border-collapse: collapse;
}
.revenue-table td.Amount,
.revenue-table th.Amount {
  text-align: right;
}

.pagination {
  display: flex;
  justify-content: center; /* 水平置中 */
  align-items: center;
  gap: 12px;                /* 按鈕之間的間距 */
  margin-top: 20px;
}
.pagination button {
  padding: 6px 12px;
  background-color: #4facfe;
  color: white;
  border: none;
  border-radius: 6px;
  cursor: pointer;
  box-shadow: 0 2px 6px rgba(0,0,0,0.1);
}

.pagination button:hover {
  background-color: #00c6ff;
}

.pagination button:disabled {
  background-color: #ccc;
  cursor: not-allowed;
}
</style>
