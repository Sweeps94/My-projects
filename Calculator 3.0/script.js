class Calculator{
    constructor(previousDisplayTextValue, currentDisplayTextValue){
        this.previousDisplayTextValue = previousDisplayTextValue
        this.currentDisplayTextValue = currentDisplayTextValue
        this.clear()
    }

    clear(){
        this.currentDisplay = ''
        this.previousDisplay = ''
        this.operation = undefined


    }

    delete(){
        this.currentDisplay = this.currentDisplay.toString().slice(0,-1)


    }

    addNumber(number){
        if(number === '.' && this.currentDisplay.includes('.')) return
        this.currentDisplay = this.currentDisplay.toString() + number.toString()
    }

    chooseOperation(operation) {
        if (this.currentDisplay === '') return
        if (this.previousDisplay !== ''){
            this.compute()
        }
        this.operation = operation
        this.previousDisplay = this.currentDisplay
        this.currentDisplay = ''
        
    }

    compute(){
        let sum
        const prev = parseFloat(this.previousDisplay)
        const current = parseFloat(this.currentDisplay)
        if (isNaN(prev) || isNaN(current)) return
        switch (this.operation){
            case '+':
                sum = prev + current
                break
            case '-':
                sum = prev - current
                break
            case '*':
                sum = prev * current
                break
            case '÷':
                sum = prev / current
                break
            default:
                return
        }
        this.currentDisplay = sum
        this.operation = undefined
        this.previousDisplay = ''

    }

    getDisplayNumber(number){
        const stringNumber = number.toString()
        const intDig = parseFloat(stringNumber.split('.')[0])
        const decimalDig = stringNumber.split('.')[1]
        let intDisplay
        if(isNaN(intDig)){
            intDisplay = ''
        }
            else{
            intDisplay = intDig.toLocaleString('en',{
            maximumFractionDigits: 0 })
        }
        if (decimalDig != null){
            return `${intDisplay}.${decimalDig}`
        } else {
            return intDisplay
        }
    }

    updateDisplay(){
        this.currentDisplayTextValue.innerText = 
            this.getDisplayNumber(this.currentDisplay)
        if (this.operation != null){
            this.previousDisplayTextValue.innerText = 
            `${this.previousDisplay} ${this.operation}`
        }
        else{
            this.previousDisplayTextValue.innerText = ''
        }

    }


}


const numberButtons = document.querySelectorAll('[data-number]')
const operationButtons = document.querySelectorAll('[data-operation]')
const equalsButton = document.querySelector('[data-equals]')
const deleteButton= document.querySelector('[data-delete]')
const allClearButton = document.querySelector('[data-all-clear]')
const previousDisplayTextValue = document.querySelector('[data-previous]')
const currentDisplayTextValue = document.querySelector('[data-current]')

const calculator = new Calculator(previousDisplayTextValue, currentDisplayTextValue)

numberButtons.forEach(button => {
    button.addEventListener('click', () => {
        calculator.addNumber(button.innerText)
        calculator.updateDisplay()
    })
})

operationButtons.forEach(button => {
    button.addEventListener('click', () => {
        calculator.chooseOperation(button.innerText)
        calculator.updateDisplay()
    })
})

equalsButton.addEventListener('click', button =>{
    calculator.compute()
    calculator.updateDisplay()

})

allClearButton.addEventListener('click', button =>{
    calculator.clear()
    calculator.updateDisplay()

})

deleteButton.addEventListener('click', button =>{
    calculator.delete()
    calculator.updateDisplay()

})
