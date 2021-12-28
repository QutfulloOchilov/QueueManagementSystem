package tj.behruz.queuemanagement.presentation.schedule


import android.annotation.SuppressLint
import android.graphics.Color
import android.view.LayoutInflater
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import tj.behruz.queuemanagement.databinding.DateItemBinding

class TimeAdapter(val times: List<String>) : RecyclerView.Adapter<TimeAdapter.TimeViewHolder>() {

    override fun getItemCount() = times.size
    private var selectedPosition = -1
    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): TimeViewHolder {
        val binding = DateItemBinding.inflate(LayoutInflater.from(parent.context), parent, false)
        return TimeViewHolder(binding)
    }

    override fun onBindViewHolder(
        holder: TimeViewHolder,
        @SuppressLint("RecyclerView") position: Int
    ) {
        val item = times[position]
        holder.setTime(item)
        val back =
            if (selectedPosition == position) Color.parseColor("#64BEAB") else Color.parseColor("#DBE7E5")
        val textColor =
            if (selectedPosition == position) Color.parseColor("#FFFFFF") else Color.parseColor("#000000")
        holder.binding.root.setCardBackgroundColor(back)
        holder.binding.time.setTextColor(textColor)
        holder.itemView.setOnClickListener {
            selectedPosition = position
            notifyDataSetChanged()
        }
    }


    inner class TimeViewHolder(val binding: DateItemBinding) :
        RecyclerView.ViewHolder(binding.root) {

        fun setTime(time: String) {
            binding.time.text = time
        }
    }

}