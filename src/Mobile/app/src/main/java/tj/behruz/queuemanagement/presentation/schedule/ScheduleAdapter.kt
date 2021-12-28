package tj.behruz.queuemanagement.presentation.schedule

import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import tj.behruz.queuemanagement.databinding.ScheduleHeaderBinding
import tj.behruz.queuemanagement.databinding.ScheduleItemBinding
import tj.behruz.queuemanagement.domain.entity.ScheduleItem
import tj.behruz.queuemanagement.presentation.HEADER

class ScheduleAdapter(private val items: List<ScheduleItem>, val itemHandler: (Any) -> Unit) :
    RecyclerView.Adapter<RecyclerView.ViewHolder>() {

    override fun getItemCount() = items.size

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): RecyclerView.ViewHolder {
        return if (viewType == HEADER) {
            val binding =
                ScheduleHeaderBinding.inflate(LayoutInflater.from(parent.context), parent, false)
            ScheduleHeaderViewHolder(binding)
        } else {
            val binding =
                ScheduleItemBinding.inflate(LayoutInflater.from(parent.context), parent, false)
            ScheduleItemViewHolder(binding)
        }
    }

    override fun onBindViewHolder(holder: RecyclerView.ViewHolder, position: Int) {
        val currentItem = items[position]
        if (currentItem.viewType == HEADER) {
            (holder as ScheduleHeaderViewHolder).setHeader(currentItem.header)
        } else {
            (holder as ScheduleItemViewHolder).setItems(currentItem.items as List<String>)

        }
    }


    override fun getItemViewType(position: Int): Int {
        return items[position].viewType
    }

    inner class ScheduleHeaderViewHolder(val binding: ScheduleHeaderBinding) :
        RecyclerView.ViewHolder(binding.root) {
        fun setHeader(header: String) {
            binding.headerName.text = header
        }
    }

    inner class ScheduleItemViewHolder(val binding: ScheduleItemBinding) :
        RecyclerView.ViewHolder(binding.root) {

        fun setItems(item: List<String>) {
            binding.root.adapter = TimeAdapter(item)
        }


    }


}